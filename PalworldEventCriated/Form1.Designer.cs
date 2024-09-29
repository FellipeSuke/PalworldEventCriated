namespace PalworldEventCriated
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        //private void InitializeComponent()
        //{
        //    this.components = new System.ComponentModel.Container();
        //    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        //    this.ClientSize = new System.Drawing.Size(800, 450);
        //    this.Text = "Form1";
        //}

        #endregion

        private TabControl tabControl1;
        private TabPage QuenteFrio;
        private TabPage ControleDePonto;
        private Label label1;
        private Button btnColetaLocal;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label6;
        private ListBox lbPlayersIgnorados;
        private Label label10;
        private TextBox txtToleranciaPerigo;
        private Label label9;
        private TextBox txtToleranciaProximaMP;
        private Label label8;
        private TextBox txtToleranciaProximaP;
        private Label label7;
        private TextBox txttoleranciaProximaM;
        private Label label11;
        private TextBox txtToleranciaProximaL;
        private Button btnIgnoraPlayer;
        private PictureBox pictureBox1;
        private TextBox tbDiscordWebHook;
        private CheckBox cbTesteWebHook;
        private Label label2;
        private TextBox tbDiscordWebHookTeste;
        private TextBox tbFileLocationY;
        private TextBox tbFileLocationX;
        private TextBox tbTesouroName;
        private Label label12;
        private Button btnLimparIgnorados;
        private Label label13;
        private Label label14;
        private TextBox tbMensagemWebHook;
        private Button btnEnviarMensagem;
        static CheckBox cbBroadcastApi;
        static ListBox lstPlayers;
        static TextBox txtLogs;
    }
}
