using CSSExternal.Classes.SDK;
using CSSExternal.Classes.SDK.Classes;
using LFOverlay.Classes;
using Memorys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSExternal.Forms
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
        }

        public static Thread thRender = new Thread(Render) { IsBackground = true };
        public static Thread thFeatures = new Thread(Features) { IsBackground = true };
        public static Thread thOverlayUpdate = new Thread(OverlayUpdate) { IsBackground = true };

        static int recoilMs = 0;
        private void MainForm_Load(object sender, EventArgs e)
        {
            cbESPType.SelectedIndex = 0;
            if(Game.Initalize())
            {
                Overlay.Initalize();
                thOverlayUpdate.Start();
                thRender.Start();
                thFeatures.Start();
            }
            else
            {
                Environment.Exit(0);
            }
        }

        public static void Render()
        {
            while(Game.Initalized)
            {
                if (!Overlay.Visible) continue;

                Entity LocalPlayer = new Entity(Memory.Read<int>(Game.Client + Offsets.dwLocalPlayer));
                if (LocalPlayer.Address == 0) continue;

                int ClientState = Memory.Read<int>(Game.Engine + Offsets.dwClientState);
                float[] Viewmatrix = Memory.ReadMatrix<float>(ClientState + Offsets.dwClientState_ViewMatrix, 16);
                float MaxDist = 999999;
                Entity targetEntity = default;
                for (int i = 0; i < 32; i++)
                {
                    Entity entity = new Entity(Memory.Read<int>(Game.Client + Offsets.dwEntityList + i * 0x10)); // 0x10 -> Entity Size
                    if (entity.Address <= 0 || entity.Address == LocalPlayer.Address) continue;
                    if (entity.Dormant) continue;
                    if(entity.Team == Enums.Team.None || entity.Team == Enums.Team.Spectator) continue;
                    if (entity.Health <= 0) continue;
                    if ((entity.Flags == 768 || entity.Flags == 0 || entity.Flags == 772) && entity.Health <= 1) continue;

                    bool entityCourched = (entity.Flags == 775 || entity.Flags == 773 || entity.Flags == 783 || entity.Flags == 771 || entity.Flags == 779);
                    if (Memory.WorldToScreen(entity.Origin, out Vector2 OriginPosition2D, Viewmatrix, Overlay.Width, Overlay.Height) && Memory.WorldToScreen(entityCourched ? entity.CrouchHeadLevel : entity.HeadLevel, out Vector2 HeadPosition2D, Viewmatrix, Overlay.Width, Overlay.Height))
                    {
                        float BoxHeight = OriginPosition2D.Y - HeadPosition2D.Y;
                        float BoxWidth = BoxHeight / 2.4f;

                        float x1 = HeadPosition2D.X - (BoxWidth / 2f);
                        float y1 = HeadPosition2D.Y;

                        if (Settings.Snaplines)
                            Overlay.Line(Overlay.Width / 2, Overlay.Height, (int)OriginPosition2D.X, (int)OriginPosition2D.Y, (entity.TeamNum == LocalPlayer.TeamNum) ? Color.Blue : Color.Red);
                        if (Settings.ESP)
                        {
                            if(Settings.ESPType == Settings.BoxType.Rectangle)
                                Overlay.Rectangle((int)x1, (int)y1, (int)BoxWidth, (int)BoxHeight, (entity.TeamNum == LocalPlayer.TeamNum) ? Color.Blue : Color.Red);
                            else if (Settings.ESPType == Settings.BoxType.Corner)
                                Overlay.CornerBox((int)x1, (int)y1, (int)BoxWidth, (int)BoxHeight, 1, (entity.TeamNum == LocalPlayer.TeamNum) ? Color.Blue : Color.Red);
                        }
                        if(Settings.HealthBar)
                            Overlay.Bar((int)(x1 + BoxWidth + (BoxWidth / 12)), (int)HeadPosition2D.Y, (int)(BoxWidth / 8), (int)(BoxHeight), 1, Color.FromArgb(2, 2, 2), entity.Health, 100, Color.LimeGreen);

                        if(Settings.Aimbot)
                        {
                            if (entity.Team != LocalPlayer.Team)
                            {
                                float dist = Vector2.Distance(new Vector2(Overlay.Width / 2, Overlay.Height / 2), HeadPosition2D);
                                if(dist  < Settings.AimbotFOV)
                                {
                                    if (dist < MaxDist)
                                    {
                                        MaxDist = dist;
                                        targetEntity = entity;
                                    }
                                }
                            }
                        }
                    }
                }

                if(Settings.Aimbot_DrawFOV)
                {
                    Overlay.Circle(Overlay.Width / 2, Overlay.Height / 2, Settings.AimbotFOV * 2, Color.White);
                }
                if(targetEntity != default && Utils.IsKeyPushedDown(Keys.XButton2) && Settings.Aimbot)
                {
                    bool entityCourched = (targetEntity.Flags == 775 || targetEntity.Flags == 773 || targetEntity.Flags == 783 || targetEntity.Flags == 771 || targetEntity.Flags == 779);
                    if (Memory.WorldToScreen(entityCourched ? targetEntity.CrouchEyeLevel : targetEntity.EyeLevel, out Vector2 HeadPosition2D, Viewmatrix, Overlay.Width, Overlay.Height))
                    {
                        Utils.move_to(HeadPosition2D.X, HeadPosition2D.Y + recoilMs, 1f, Overlay.Width, Overlay.Height);
                        if(Settings.Aimbot_RecoilHelper && Utils.IsKeyPushedDown(Keys.LButton))
                        {
                            recoilMs+=3;
                            if (recoilMs > 60)
                            {
                                recoilMs = 0;
                            }
                        }
                        else
                            recoilMs = 0;
                    }
                }
                Overlay.Text("FPS : " + Overlay.RenderFPS, 10, 10, Color.White);
                Overlay.Render();
            }
        }

        public static void Features()
        {
            while(Game.Initalized)
            {
                Entity LocalPlayer = new Entity(Memory.Read<int>(Game.Client + Offsets.dwLocalPlayer));
                if (LocalPlayer.Address == 0) continue;

                if (Settings.BunnyHop)
                {
                    if (Utils.IsKeyPushedDown(Keys.Space))
                    {
                        if (LocalPlayer.Flags == 257)
                        {
                            Memory.Write<int>(Game.Client + Offsets.dwForceJump, 6);
                        }
                    }
                }
                else
                {
                    Thread.Sleep(1500);
                }
            }
        }

        public static void OverlayUpdate()
        {
            while(true)
            {
                if(Utils.ForegroundProcess().ProcessName == "hl2")
                {
                    Overlay.TopMost = true;
                    Overlay.Visible = true;
                    if (Utils.GetWindowClientInternal(Utils.ForegroundProcess().MainWindowHandle, out LFOverlay.Classes.Variables.Structs.RECT rect))
                    {
                        Overlay.X = rect.left;
                        Overlay.Y = rect.top;

                        Overlay.Width = rect.right - rect.left;
                        Overlay.Height = rect.bottom - rect.top;
                    }
                }
                else
                {
                    Overlay.TopMost = false;
                    Overlay.Visible = false;
                }

                Thread.Sleep(1500);
            }
        }

        private void cbESP_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ESP = cbESP.Checked;
        }

        private void cbSnaplines_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Snaplines = cbSnaplines.Checked;
        }

        private void cbHealthBar_CheckedChanged(object sender, EventArgs e)
        {
            Settings.HealthBar = cbHealthBar.Checked;
        }

        private void cbESPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.ESPType = (Settings.BoxType)cbESPType.SelectedIndex;
        }

        private void cbAimbot_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Aimbot = cbAimbot.Checked;
        }

        private void cbAimbotDrawFOV_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Aimbot_DrawFOV = cbAimbotDrawFOV.Checked;
        }

        private void cbAimbotRecoilHelper_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Aimbot_RecoilHelper = cbAimbotRecoilHelper.Checked;
        }

        private void tbAimbotFOV_Scroll(object sender, ScrollEventArgs e)
        {
            Settings.AimbotFOV = tbAimbotFOV.Value;
            cbAimbotDrawFOV.Text = "Draw FOV [" + Settings.AimbotFOV + "]";
        }

        private void cbBunnyHop_CheckedChanged(object sender, EventArgs e)
        {
            Settings.BunnyHop = cbBunnyHop.Checked;
        }
    }
}
