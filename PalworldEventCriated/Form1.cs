namespace PalworldEventCriated
{
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net;
    using System.Text;
    using System.Windows.Forms;


    public partial class Form1 : Form
    {
        // Definindo os componentes do formulário
        private Label lblServer;
        private TextBox txtServer;
        private Label lblPort;
        private TextBox txtPort;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnConnect;
        private Button btnNotifyEvent;
        private Label lblPlayers;
        private Label lblLogs;
        private Form2 _form2; // Referência ao Form2

        static int toleranciaProximaL;
        static int toleranciaProximaM;
        static int toleranciaProximaP;
        static int toleranciaProximaMP;
        static int toleranciaPerigo;
        static bool eventoDisponivel = true;
        static Dictionary<string, string> lastProximityStatus = new Dictionary<string, string>();
        public static List<string> playersLoading = new List<string>();
        private bool isRunning = false;
        private bool isConnected = false;
        static string baseDir;
        static string apiUrl;
        static string authUsername = "admin";
        static string authPassword;
        static string whatsappApiUrl;
        static string whatsappApiKey;
        static string ChatIdContact;
        static string discordWebhookUrl;
        static string logsDir;
        static string playersCsvFile;
        static string responseFile;
        static string curlStatusFile;
        static string curlOutputFile;
        static BancoDeDados.UsuarioBd usuarioBd;
        public Form1(Form2 form2)
        {
            InitializeComponent();
            _form2 = form2;
            this.FormClosing += Form1_FormClosing;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblServer = new Label();
            txtServer = new TextBox();
            lblPort = new Label();
            txtPort = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnConnect = new Button();
            btnNotifyEvent = new Button();
            lstPlayers = new ListBox();
            txtLogs = new TextBox();
            lblPlayers = new Label();
            lblLogs = new Label();
            tabControl1 = new TabControl();
            QuenteFrio = new TabPage();
            cbBroadcastApi = new CheckBox();
            btnLimparIgnorados = new Button();
            tbTesouroName = new TextBox();
            label12 = new Label();
            tbFileLocationY = new TextBox();
            tbFileLocationX = new TextBox();
            cbTesteWebHook = new CheckBox();
            label11 = new Label();
            txtToleranciaProximaL = new TextBox();
            label10 = new Label();
            txtToleranciaPerigo = new TextBox();
            label9 = new Label();
            txtToleranciaProximaMP = new TextBox();
            label8 = new Label();
            txtToleranciaProximaP = new TextBox();
            label7 = new Label();
            txttoleranciaProximaM = new TextBox();
            label6 = new Label();
            lbPlayersIgnorados = new ListBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tbDiscordWebHookTeste = new TextBox();
            label1 = new Label();
            tbDiscordWebHook = new TextBox();
            ControleDePonto = new TabPage();
            label5 = new Label();
            btnColetaLocal = new Button();
            btnIgnoraPlayer = new Button();
            pictureBox1 = new PictureBox();
            label13 = new Label();
            label14 = new Label();
            tbMensagemWebHook = new TextBox();
            btnEnviarMensagem = new Button();
            tabControl1.SuspendLayout();
            QuenteFrio.SuspendLayout();
            ControleDePonto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Location = new Point(20, 41);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(53, 15);
            lblServer.TabIndex = 0;
            lblServer.Text = "Servidor:";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(79, 33);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(150, 23);
            txtServer.TabIndex = 1;
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(248, 41);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(59, 15);
            lblPort.TabIndex = 2;
            lblPort.Text = "Porta Api:";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(313, 33);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(92, 23);
            txtPort.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(427, 41);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(42, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Senha:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(475, 33);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(106, 23);
            txtPassword.TabIndex = 5;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(606, 33);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(100, 23);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Conectar";
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnNotifyEvent
            // 
            btnNotifyEvent.Enabled = false;
            btnNotifyEvent.Location = new Point(24, 353);
            btnNotifyEvent.Name = "btnNotifyEvent";
            btnNotifyEvent.Size = new Size(100, 30);
            btnNotifyEvent.TabIndex = 7;
            btnNotifyEvent.Text = "Iniciar Evento";
            btnNotifyEvent.Click += BtnNotifyEvent_Click;
            // 
            // lstPlayers
            // 
            lstPlayers.ItemHeight = 15;
            lstPlayers.Location = new Point(675, 145);
            lstPlayers.Name = "lstPlayers";
            lstPlayers.Size = new Size(129, 364);
            lstPlayers.TabIndex = 8;
            // 
            // txtLogs
            // 
            txtLogs.Location = new Point(20, 539);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.Size = new Size(378, 109);
            txtLogs.TabIndex = 9;
            // 
            // lblPlayers
            // 
            lblPlayers.AutoSize = true;
            lblPlayers.Location = new Point(675, 120);
            lblPlayers.Name = "lblPlayers";
            lblPlayers.Size = new Size(129, 15);
            lblPlayers.TabIndex = 10;
            lblPlayers.Text = "Jogadores Conectados:";
            // 
            // lblLogs
            // 
            lblLogs.AutoSize = true;
            lblLogs.Location = new Point(20, 519);
            lblLogs.Name = "lblLogs";
            lblLogs.Size = new Size(35, 15);
            lblLogs.TabIndex = 11;
            lblLogs.Text = "Logs:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(QuenteFrio);
            tabControl1.Controls.Add(ControleDePonto);
            tabControl1.Location = new Point(20, 96);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(653, 417);
            tabControl1.TabIndex = 12;
            // 
            // QuenteFrio
            // 
            QuenteFrio.Controls.Add(cbBroadcastApi);
            QuenteFrio.Controls.Add(btnLimparIgnorados);
            QuenteFrio.Controls.Add(tbTesouroName);
            QuenteFrio.Controls.Add(label12);
            QuenteFrio.Controls.Add(tbFileLocationY);
            QuenteFrio.Controls.Add(tbFileLocationX);
            QuenteFrio.Controls.Add(cbTesteWebHook);
            QuenteFrio.Controls.Add(label11);
            QuenteFrio.Controls.Add(txtToleranciaProximaL);
            QuenteFrio.Controls.Add(label10);
            QuenteFrio.Controls.Add(txtToleranciaPerigo);
            QuenteFrio.Controls.Add(label9);
            QuenteFrio.Controls.Add(txtToleranciaProximaMP);
            QuenteFrio.Controls.Add(label8);
            QuenteFrio.Controls.Add(txtToleranciaProximaP);
            QuenteFrio.Controls.Add(label7);
            QuenteFrio.Controls.Add(txttoleranciaProximaM);
            QuenteFrio.Controls.Add(label6);
            QuenteFrio.Controls.Add(lbPlayersIgnorados);
            QuenteFrio.Controls.Add(label4);
            QuenteFrio.Controls.Add(label3);
            QuenteFrio.Controls.Add(label2);
            QuenteFrio.Controls.Add(tbDiscordWebHookTeste);
            QuenteFrio.Controls.Add(label1);
            QuenteFrio.Controls.Add(tbDiscordWebHook);
            QuenteFrio.Controls.Add(btnNotifyEvent);
            QuenteFrio.Location = new Point(4, 24);
            QuenteFrio.Name = "QuenteFrio";
            QuenteFrio.Padding = new Padding(3);
            QuenteFrio.Size = new Size(645, 389);
            QuenteFrio.TabIndex = 2;
            QuenteFrio.Text = "Quente e Frio";
            QuenteFrio.UseVisualStyleBackColor = true;
            // 
            // cbBroadcastApi
            // 
            cbBroadcastApi.AutoSize = true;
            cbBroadcastApi.Location = new Point(469, 353);
            cbBroadcastApi.Name = "cbBroadcastApi";
            cbBroadcastApi.Size = new Size(149, 19);
            cbBroadcastApi.TabIndex = 32;
            cbBroadcastApi.Text = "Enviar msg ao Palworld";
            cbBroadcastApi.UseVisualStyleBackColor = true;
            // 
            // btnLimparIgnorados
            // 
            btnLimparIgnorados.Location = new Point(469, 270);
            btnLimparIgnorados.Name = "btnLimparIgnorados";
            btnLimparIgnorados.Size = new Size(63, 23);
            btnLimparIgnorados.TabIndex = 16;
            btnLimparIgnorados.Text = "Limpar";
            btnLimparIgnorados.Click += btnLimparIgnorados_Click;
            // 
            // tbTesouroName
            // 
            tbTesouroName.Location = new Point(212, 110);
            tbTesouroName.Name = "tbTesouroName";
            tbTesouroName.Size = new Size(126, 23);
            tbTesouroName.TabIndex = 31;
            tbTesouroName.Text = "Tesouro Verde";
            tbTesouroName.TextAlign = HorizontalAlignment.Center;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(224, 92);
            label12.Name = "label12";
            label12.Size = new Size(104, 15);
            label12.TabIndex = 30;
            label12.Text = "Nome do Tesouro:";
            // 
            // tbFileLocationY
            // 
            tbFileLocationY.Location = new Point(132, 305);
            tbFileLocationY.Name = "tbFileLocationY";
            tbFileLocationY.Size = new Size(73, 23);
            tbFileLocationY.TabIndex = 29;
            // 
            // tbFileLocationX
            // 
            tbFileLocationX.Location = new Point(132, 276);
            tbFileLocationX.Name = "tbFileLocationX";
            tbFileLocationX.Size = new Size(73, 23);
            tbFileLocationX.TabIndex = 28;
            // 
            // cbTesteWebHook
            // 
            cbTesteWebHook.AutoSize = true;
            cbTesteWebHook.Location = new Point(18, 88);
            cbTesteWebHook.Name = "cbTesteWebHook";
            cbTesteWebHook.Size = new Size(106, 19);
            cbTesteWebHook.TabIndex = 27;
            cbTesteWebHook.Text = "Iniciar em teste";
            cbTesteWebHook.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 130);
            label11.Name = "label11";
            label11.Size = new Size(75, 15);
            label11.TabIndex = 25;
            label11.Text = "Muito Longe";
            // 
            // txtToleranciaProximaL
            // 
            txtToleranciaProximaL.ForeColor = SystemColors.WindowText;
            txtToleranciaProximaL.Location = new Point(92, 122);
            txtToleranciaProximaL.Name = "txtToleranciaProximaL";
            txtToleranciaProximaL.Size = new Size(73, 23);
            txtToleranciaProximaL.TabIndex = 26;
            txtToleranciaProximaL.Text = "150000";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 246);
            label10.Name = "label10";
            label10.Size = new Size(70, 15);
            label10.TabIndex = 23;
            label10.Text = "Muito Perto";
            // 
            // txtToleranciaPerigo
            // 
            txtToleranciaPerigo.Location = new Point(92, 238);
            txtToleranciaPerigo.Name = "txtToleranciaPerigo";
            txtToleranciaPerigo.Size = new Size(73, 23);
            txtToleranciaPerigo.TabIndex = 24;
            txtToleranciaPerigo.Text = "200";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(51, 217);
            label9.Name = "label9";
            label9.Size = new Size(35, 15);
            label9.TabIndex = 21;
            label9.Text = "Perto";
            // 
            // txtToleranciaProximaMP
            // 
            txtToleranciaProximaMP.Location = new Point(92, 209);
            txtToleranciaProximaMP.Name = "txtToleranciaProximaMP";
            txtToleranciaProximaMP.Size = new Size(73, 23);
            txtToleranciaProximaMP.TabIndex = 22;
            txtToleranciaProximaMP.Text = "15000";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(45, 188);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 19;
            label8.Text = "Médio";
            // 
            // txtToleranciaProximaP
            // 
            txtToleranciaProximaP.Location = new Point(92, 180);
            txtToleranciaProximaP.Name = "txtToleranciaProximaP";
            txtToleranciaProximaP.Size = new Size(73, 23);
            txtToleranciaProximaP.TabIndex = 20;
            txtToleranciaProximaP.Text = "40000";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 159);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 17;
            label7.Text = "Longe";
            // 
            // txttoleranciaProximaM
            // 
            txttoleranciaProximaM.Location = new Point(92, 151);
            txttoleranciaProximaM.Name = "txttoleranciaProximaM";
            txttoleranciaProximaM.Size = new Size(73, 23);
            txttoleranciaProximaM.TabIndex = 18;
            txttoleranciaProximaM.Text = "85000";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(403, 92);
            label6.Name = "label6";
            label6.Size = new Size(116, 15);
            label6.TabIndex = 14;
            label6.Text = "Jogadores Ignorados";
            // 
            // lbPlayersIgnorados
            // 
            lbPlayersIgnorados.ItemHeight = 15;
            lbPlayersIgnorados.Location = new Point(403, 110);
            lbPlayersIgnorados.Name = "lbPlayersIgnorados";
            lbPlayersIgnorados.Size = new Size(129, 154);
            lbPlayersIgnorados.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 313);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 15;
            label4.Text = "Localização em Y:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 284);
            label3.Name = "label3";
            label3.Size = new Size(101, 15);
            label3.TabIndex = 14;
            label3.Text = "Localização em X:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 56);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 10;
            label2.Text = "WebHook Teste";
            // 
            // tbDiscordWebHookTeste
            // 
            tbDiscordWebHookTeste.Location = new Point(133, 53);
            tbDiscordWebHookTeste.Name = "tbDiscordWebHookTeste";
            tbDiscordWebHookTeste.Size = new Size(399, 23);
            tbDiscordWebHookTeste.TabIndex = 11;
            tbDiscordWebHookTeste.Text = "https://discordapp.com/api/webhooks/1262885751532552234/HBgF6Fkm76bsNXxsLr_SDfAhjgD_2hTEP7PUkF5eT7RX6nhEj57lGq3BllBZtvNvWnGo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 27);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 8;
            label1.Text = "WebHook Discord";
            // 
            // tbDiscordWebHook
            // 
            tbDiscordWebHook.Location = new Point(133, 24);
            tbDiscordWebHook.Name = "tbDiscordWebHook";
            tbDiscordWebHook.Size = new Size(399, 23);
            tbDiscordWebHook.TabIndex = 9;
            tbDiscordWebHook.Text = "https://discordapp.com/api/webhooks/1264728721835954196/ZZRHjttkYbN-WL1EkgWntgdZtLuuijeFFafSY0xXytbhukvgJpRmuGpz2qKPEY5QgmwS";
            // 
            // ControleDePonto
            // 
            ControleDePonto.Controls.Add(label5);
            ControleDePonto.Location = new Point(4, 24);
            ControleDePonto.Name = "ControleDePonto";
            ControleDePonto.Padding = new Padding(3);
            ControleDePonto.Size = new Size(645, 389);
            ControleDePonto.TabIndex = 3;
            ControleDePonto.Text = "Controle de Ponto";
            ControleDePonto.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(191, 159);
            label5.Name = "label5";
            label5.Size = new Size(105, 15);
            label5.TabIndex = 14;
            label5.Text = "EM CONSTRUÇÂO";
            // 
            // btnColetaLocal
            // 
            btnColetaLocal.Enabled = false;
            btnColetaLocal.Location = new Point(814, 194);
            btnColetaLocal.Name = "btnColetaLocal";
            btnColetaLocal.Size = new Size(91, 43);
            btnColetaLocal.TabIndex = 13;
            btnColetaLocal.Text = "Coletar localização";
            btnColetaLocal.Click += btnColetaLocal_Click;
            // 
            // btnIgnoraPlayer
            // 
            btnIgnoraPlayer.Enabled = false;
            btnIgnoraPlayer.Location = new Point(814, 145);
            btnIgnoraPlayer.Name = "btnIgnoraPlayer";
            btnIgnoraPlayer.Size = new Size(91, 43);
            btnIgnoraPlayer.TabIndex = 14;
            btnIgnoraPlayer.Text = "Ignorar jogador";
            btnIgnoraPlayer.Click += btnIgnoraPlayer_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(745, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 97);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(5, 2);
            label13.Name = "label13";
            label13.Size = new Size(184, 15);
            label13.TabIndex = 16;
            label13.Text = "Desenvolvido por Suke CodeCraft";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(404, 521);
            label14.Name = "label14";
            label14.Size = new Size(122, 15);
            label14.TabIndex = 17;
            label14.Text = "Mensagem WebHook";
            // 
            // tbMensagemWebHook
            // 
            tbMensagemWebHook.Location = new Point(404, 539);
            tbMensagemWebHook.Multiline = true;
            tbMensagemWebHook.Name = "tbMensagemWebHook";
            tbMensagemWebHook.Size = new Size(400, 53);
            tbMensagemWebHook.TabIndex = 18;
            // 
            // btnEnviarMensagem
            // 
            btnEnviarMensagem.Enabled = false;
            btnEnviarMensagem.Location = new Point(704, 598);
            btnEnviarMensagem.Name = "btnEnviarMensagem";
            btnEnviarMensagem.Size = new Size(100, 23);
            btnEnviarMensagem.TabIndex = 19;
            btnEnviarMensagem.Text = "Enviar";
            btnEnviarMensagem.Click += btnEnviarMensagem_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(919, 666);
            Controls.Add(btnEnviarMensagem);
            Controls.Add(label14);
            Controls.Add(tbMensagemWebHook);
            Controls.Add(label13);
            Controls.Add(pictureBox1);
            Controls.Add(btnIgnoraPlayer);
            Controls.Add(btnColetaLocal);
            Controls.Add(tabControl1);
            Controls.Add(lblServer);
            Controls.Add(txtServer);
            Controls.Add(lblPort);
            Controls.Add(txtPort);
            Controls.Add(lblPassword);
            Controls.Add(txtPassword);
            Controls.Add(btnConnect);
            Controls.Add(lstPlayers);
            Controls.Add(txtLogs);
            Controls.Add(lblPlayers);
            Controls.Add(lblLogs);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Controle com Servidor de Eventos";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            QuenteFrio.ResumeLayout(false);
            QuenteFrio.PerformLayout();
            ControleDePonto.ResumeLayout(false);
            ControleDePonto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        // Eventos de clique dos botões
        private async void BtnConnect_Click(object sender, EventArgs e)
        {

            if (!isConnected) // Se não está conectado, tenta conectar
            {
                string server = txtServer.Text;
                string port = txtPort.Text;
                string password = txtPassword.Text;
                authPassword = password;
                apiUrl = $"http://{server}:{port}/v1/api/";

                baseDir = AppDomain.CurrentDomain.BaseDirectory;
                logsDir = Path.Combine(baseDir, @"Dados\logs");
                playersCsvFile = Path.Combine(baseDir, @"Dados\players_data.csv");
                responseFile = Path.Combine(baseDir, @"Dados\response.json");
                CleanTempFiles();
                curlStatusFile = Path.Combine(baseDir, "Dados", "curl_status.txt");
                curlOutputFile = Path.Combine(baseDir, "Dados", "curl_output.txt");

                // Atualiza a UI para indicar que está tentando conectar
                LogsTxt($"Conectando ao servidor {server} na porta {port}");

                if (await MakeApiRequest(apiUrl, authUsername, authPassword, responseFile, curlStatusFile, curlOutputFile))
                {
                    // Conexão bem-sucedida, atualiza o estado e a UI
                    isConnected = true;
                    LogsTxt("Conectado!");
                    Invoke(new Action(() =>
                    {
                        btnConnect.Text = "Desconectar";
                        btnColetaLocal.Enabled = true;
                        btnNotifyEvent.Enabled = true;
                        btnIgnoraPlayer.Enabled = true;
                        btnEnviarMensagem.Enabled = true;
                    }));

                    // Inicia o loop de atualização enquanto está conectado
                    await Task.Run(async () =>
                    {
                        while (isConnected)
                        {
                            if (!await MakeApiRequest(apiUrl, authUsername, authPassword, responseFile, curlStatusFile, curlOutputFile))
                            {
                                LogsTxt("Erro ao atualizar dados.");
                                isConnected = false;
                            }

                            if (!ProcessJsonAndUpdateCsv(playersCsvFile, responseFile))
                            {
                                LogsTxt("Erro ao processar dados.");
                            }

                            await Task.Delay(1000); // Intervalo de 1 segundo entre as atualizações
                        }
                    });
                }
                else
                {
                    LogsTxt("Não foi possível conectar");
                    Invoke(new Action(() =>
                    {
                        btnConnect.Text = "Conectar";
                        btnNotifyEvent.Enabled = false;
                        btnColetaLocal.Enabled = false;
                        btnIgnoraPlayer.Enabled = false;
                        btnEnviarMensagem.Enabled = false;
                    }));
                }
            }
            else // Se já está conectado, desconecta
            {
                // Atualiza o estado e a UI
                isConnected = false;
                LogsTxt("Desconectado!");
                CleanTempFiles();
                Invoke(new Action(() =>
                {
                    btnConnect.Text = "Conectar";
                    btnNotifyEvent.Enabled = false;
                    btnColetaLocal.Enabled = false;
                    btnIgnoraPlayer.Enabled = false;
                    btnEnviarMensagem.Enabled = false;
                    lstPlayers.Items.Clear();
                }));
            }
        }


        private async void BtnNotifyEvent_Click(object sender, EventArgs e)
        {
            toleranciaProximaL = int.Parse(txtToleranciaProximaL.Text);
            toleranciaProximaM = int.Parse(txttoleranciaProximaM.Text);
            toleranciaProximaP = int.Parse(txtToleranciaProximaP.Text);
            toleranciaProximaMP = int.Parse(txtToleranciaProximaMP.Text);
            toleranciaPerigo = int.Parse(txtToleranciaPerigo.Text);



            if (!isRunning)
            {
                isRunning = true;
                btnNotifyEvent.Text = "Parar Evento";
                btnConnect.Enabled = false;
                discordWebhookUrl = tbDiscordWebHook.Text;
                if (cbTesteWebHook.Checked)
                {
                    discordWebhookUrl = tbDiscordWebHookTeste.Text;
                }

                LogsTxt("Evento Iniciado!");

                string directoryPath = Path.Combine(baseDir, "Dados", "Guildas");

                // Executar o loop em uma Task para não bloquear a interface
                await Task.Run(() =>
                {
                    while (isRunning && eventoDisponivel)
                    {
                        CheckCoordinatesInTextFiles(playersCsvFile);
                        Task.Delay(200).Wait(); // Intervalo de 1 segundo para evitar loop constante
                    }
                    lastProximityStatus.Clear();
                    isRunning = false;

                    if (btnNotifyEvent.InvokeRequired)
                    {
                        // O controle não está sendo acessado na thread principal, então usamos Invoke
                        btnNotifyEvent.Invoke(new Action(() =>
                        {
                            // Atualize o controle aqui
                            btnNotifyEvent.Text = "Iniciar Evento"; // Exemplo de operação
                        }));
                    }
                    else
                    {
                        // O controle já está sendo acessado na thread principal
                        btnNotifyEvent.Text = "Iniciar Evento"; // Exemplo de operação
                    }

                    if (btnNotifyEvent.InvokeRequired)
                    {
                        // O controle não está sendo acessado na thread principal, então usamos Invoke
                        btnNotifyEvent.Invoke(new Action(() =>
                        {
                            // Atualize o controle aqui
                            btnConnect.Enabled = true;
                        }));
                    }
                    else
                    {
                        // O controle já está sendo acessado na thread principal
                        btnNotifyEvent.Text = "Iniciar Evento"; // Exemplo de operação
                    }
                    LogsTxt("Evento Parado!");
                });
            }
            else
            {
                lastProximityStatus.Clear();
                isRunning = false;
                btnNotifyEvent.Text = "Iniciar Evento";
                btnConnect.Enabled = true;
                LogsTxt("Evento Parado!");
            }
        }

        public void CheckCoordinatesInTextFiles(string playersCsvFile)
        {
            try
            {
                var players = ReadPlayersFromCsv(playersCsvFile);


                int fileLocationX = int.Parse(tbFileLocationX.Text);
                int fileLocationY = int.Parse(tbFileLocationY.Text);

                foreach (var player in players)
                {
                    if (lbPlayersIgnorados.Items.Contains(player.Name))
                    {
                        //LogsTxt($"Player {player.Name} foi ignorado");
                        continue;
                    }

                    int distanceX = Math.Abs(player.LocationX - fileLocationX);
                    int distanceY = Math.Abs(player.LocationY - fileLocationY);

                    string currentStatus = GetProximityStatus(distanceX, distanceY);
                    string playerKey = $"{player.AccountName}_{tbTesouroName.Text}";

                    if (!lastProximityStatus.ContainsKey(playerKey) || lastProximityStatus[playerKey] != currentStatus)
                    {
                        SendProximityAlert(player, tbTesouroName.Text, currentStatus);
                        lastProximityStatus[playerKey] = currentStatus;
                    }
                }

            }
            catch (Exception ex)
            {

                LogsTxt($"Erro ao verificar coordenadas: {ex.Message}");
            }
        }

        public void ColectCoordinate(string playersCsvFile)
        {
            try
            {
                // Ler jogadores do CSV
                var players = ReadPlayersFromCsv(playersCsvFile);

                // Pegar as coordenadas do arquivo de texto (ou campos de texto)


                // Percorrer a lista de jogadores


                if (lstPlayers.SelectedItem != null) // ou comboBoxPlayers.SelectedItem, caso seja um ComboBox
                {
                    // Pegar o nome do jogador selecionado na lista
                    string selectedPlayerName = lstPlayers.SelectedItem.ToString(); // ou comboBoxPlayers.SelectedItem.ToString()

                    // Procurar o jogador correspondente na lista de players
                    var selectedPlayer = players.FirstOrDefault(p => p.Name.Equals(selectedPlayerName, StringComparison.OrdinalIgnoreCase));

                    if (selectedPlayer != null)
                    {
                        // Pegar as coordenadas do jogador
                        tbFileLocationX.Text = selectedPlayer.LocationX.ToString(); // Supondo que o item tenha uma propriedade X
                        tbFileLocationY.Text = selectedPlayer.LocationY.ToString(); // Supondo que o item tenha uma propriedade Y
                        lbPlayersIgnorados.Items.Add(selectedPlayer.Name);
                        LogsTxt("Coordenada atualziada com sucesso!");

                    }
                    else
                    {
                        // Jogador não encontrado
                        MessageBox.Show("Jogador não encontrado na lista.");
                    }
                }
                else
                {
                    // Nenhum jogador foi selecionado
                    MessageBox.Show("Nenhum jogador foi selecionado.");
                }

            }
            catch (Exception ex)
            {

                LogsTxt($"Erro ao verificar coordenadas");
            }
        }

        static string GetProximityStatus(int distanceX, int distanceY)
        {
            if (distanceX < toleranciaPerigo && distanceY < toleranciaPerigo)
            {
                eventoDisponivel = false;
                return "🎉 Parabéns encontrou o BAÚ! 🎉";
            }
            if (distanceX < toleranciaProximaMP && distanceY < toleranciaProximaMP)
                return "🔥🔥 Está muito perto do BAÚ! 🔥🔥";
            if (distanceX < toleranciaProximaP && distanceY < toleranciaProximaP)
                return "🔥 Está ficando quente! 🔥";
            if (distanceX < toleranciaProximaM && distanceY < toleranciaProximaM)
                return "🌡️ Está morno! 🌡️";
            if (distanceX < toleranciaProximaL && distanceY < toleranciaProximaL)
                return "❄️ Está frio, mas não tão frio! ❄️";

            return "👋 Viiiiishhh, Está muito longe do BAÚ! 👋 ";
        }

        static void SendProximityAlert(Player player, string testouroName, string message)
        {
            if (message != null)
            {
                string formattedMessage = $"{player.Name} {message} do {Path.GetFileNameWithoutExtension(testouroName)}!";
                LogsTxt(formattedMessage);

                SendDiscordNotification(formattedMessage, discordWebhookUrl);
                SendGlobalBroadcast(apiUrl, authUsername, authPassword, formattedMessage);
                if (!eventoDisponivel)
                {
                    SendDiscordNotification("############### Fim do evento ###############", discordWebhookUrl);
                    SendGlobalBroadcast(apiUrl,authUsername,authPassword, "## Fim do evento ##");

                }

            }
        }

        public bool ProcessJsonAndUpdateCsv(string playersCsvFile, string responseFile)
        {
            List<Player> existingPlayers = ReadPlayersFromCsv(playersCsvFile);
            List<Player> newPlayers = ParsePlayersFromJson(responseFile);

            List<Player> playersEntered = new List<Player>();
            List<Player> playersExited = new List<Player>();

            foreach (var newPlayer in newPlayers)
            {
                if (newPlayer.PlayerId == "None")
                {
                    // Verifica se o jogador já está na lista de loading
                    if (!playersLoading.Contains(newPlayer.AccountName))
                    {
                        // Adiciona o jogador à lista de loading e exibe a mensagem uma vez
                        playersLoading.Add(newPlayer.AccountName);
                        LogsTxt($"Account {newPlayer.AccountName} na tela de Loading");
                    }
                }
                else
                {
                    // Remove o jogador da lista de loading caso ele não esteja mais na tela de loading
                    if (playersLoading.Contains(newPlayer.AccountName))
                    {
                        playersLoading.Remove(newPlayer.AccountName);
                    }

                    // Se o jogador não está no CSV de jogadores existentes, adiciona à lista de novos jogadores
                    if (!existingPlayers.Any(p => p.AccountName == newPlayer.AccountName))
                    {
                        playersEntered.Add(newPlayer);
                    }
                }
            }

            // Verifica os jogadores que saíram
            foreach (var existingPlayer in existingPlayers)
            {
                if (!newPlayers.Any(p => p.AccountName == existingPlayer.AccountName))
                {
                    playersExited.Add(existingPlayer);
                }
            }

            // Atualiza o CSV com os novos jogadores (exclui os que estão na tela de loading)
            newPlayers.RemoveAll(p => p.PlayerId == "None");

            // Atualiza o CSV com os novos jogadores
            UpdateCsvWithPlayers(playersCsvFile, newPlayers);

            // Log de jogadores que entraram
            if (playersEntered.Count >= 1)
            {

                foreach (var player in playersEntered)
                {
                    LogsTxt($"{player.Name} entrou no servidor");
                    //SendDiscordNotification($"{player.Name} ({player.AccountName}) entrou no servidor", "1752220");
                }
            }

            // Log de jogadores que saíram
            if (playersExited.Count >= 1)
            {

                foreach (var player in playersExited)
                {
                    LogsTxt($"{player.Name} saiu do servidor");
                    Invoke(new Action(() =>
                    {
                        lstPlayers.Items.Remove(player.Name);
                    }));
                    //SendDiscordNotification($"{player.Name} ({player.AccountName}) saiu do servidor", "10181046");
                }
            }

            return true;
        }


        static void UpdateCsvWithPlayers(string filePath, List<Player> players)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (var player in players)
                    {
                        string line = $"{player.Name},{player.AccountName},{player.LocationX},{player.LocationY}";
                        writer.WriteLine(line);

                        // Verifica se é necessário invocar na thread da UI
                        if (lstPlayers.InvokeRequired)
                        {
                            lstPlayers.Invoke(new Action(() =>
                            {
                                if (!lstPlayers.Items.Contains(player.Name))
                                {
                                    lstPlayers.Items.Add(player.Name);
                                }
                            }));
                        }
                        else
                        {
                            if (!lstPlayers.Items.Contains(player.Name))
                            {
                                lstPlayers.Items.Add(player.Name);
                            }
                        }
                    }
                }
                //LogsTxt("Arquivo CSV atualizado.");
            }
            catch (Exception ex)
            {
                LogsTxt(ex.ToString());
            }

        }


        static List<Player> ReadPlayersFromCsv(string filePath)
        {
            List<Player> players = new List<Player>();
            if (!File.Exists(filePath))
                return players;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var cols = line.Split(',');
                if (cols.Length >= 4)
                {
                    players.Add(new Player
                    {
                        Name = cols[0],
                        AccountName = cols[1],
                        LocationX = int.Parse(cols[2]),
                        LocationY = int.Parse(cols[3])
                    });
                }
            }
            return players;
        }

        static List<Player> ParsePlayersFromJson(string filePath)
        {
            List<Player> players = new List<Player>();
            string jsonContent;
            JObject json = null; // Inicializando com null

            try
            {
                jsonContent = File.ReadAllText(filePath);
                json = JObject.Parse(jsonContent);
            }
            catch
            {
                LogsTxt("Server OffLine, sem Json");
                return players; // Retorna uma lista vazia
            }

            // Verifica se o json foi corretamente inicializado
            if (json != null && json["players"] != null)
            {
                foreach (var player in json["players"])
                {
                    players.Add(new Player
                    {
                        Name = (string)player["name"],
                        AccountName = (string)player["accountName"],
                        PlayerId = (string)player["playerId"],
                        LocationX = (int)Math.Floor((double)player["location_x"]),
                        LocationY = (int)Math.Floor((double)player["location_y"])
                    });
                }
            }
            return players;
        }


        public static void InitializeDirectoriesAndFiles()
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string dadosPath = Path.Combine(basePath, "Dados");
            string logsPath = Path.Combine(dadosPath, "logs");
            string guildasPath = Path.Combine(dadosPath, "Guildas");
            string playersDataFile = Path.Combine(dadosPath, "players_data.csv");
            string responseFile = Path.Combine(dadosPath, "response.json");

            try
            {
                // Cria o diretório Dados se não existir
                if (!Directory.Exists(dadosPath))
                {
                    Directory.CreateDirectory(dadosPath);
                    Console.WriteLine($"Diretório criado: {dadosPath}");
                }

                // Cria o diretório logs se não existir
                if (!Directory.Exists(logsPath))
                {
                    Directory.CreateDirectory(logsPath);
                    Console.WriteLine($"Diretório criado: {logsPath}");
                }

                // Cria o diretório Guildas se não existir
                if (!Directory.Exists(guildasPath))
                {
                    Directory.CreateDirectory(guildasPath);
                    Console.WriteLine($"Diretório criado: {guildasPath}");
                }

                // Cria o arquivo players_data.csv se não existir
                if (!File.Exists(playersDataFile))
                {
                    File.WriteAllText(playersDataFile, string.Empty);
                    Console.WriteLine($"Arquivo criado: {playersDataFile}");
                }

                // Cria o arquivo response.json se não existir
                if (!File.Exists(responseFile))
                {
                    File.WriteAllText(responseFile, string.Empty);
                    Console.WriteLine($"Arquivo criado: {responseFile}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao criar diretórios ou arquivos: {ex.Message}");
            }
        }

        public static async Task SendDiscordNotification(string message, string discordWebhookUrl, string color = "5763719")
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(discordWebhookUrl);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = new JObject(
                        new JProperty("embeds", new JArray(
                            new JObject(
                                new JProperty("description", message),
                                new JProperty("color", color)
                            )
                        ))
                    ).ToString();

                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    Console.WriteLine(result);
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao enviar notificação para o Discord: {ex.Message}");
            }
        }



        public static async Task SendGlobalBroadcast(string apiUrl, string username, string password, string broadcastMessage)
        {
            if (cbBroadcastApi.Checked)
            {
                try
                {
                    using (var client = new HttpClient())
                    {
                        // Adiciona o cabeçalho de autenticação
                        var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes($"{username}:{password}"));
                        client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authInfo);

                        // Cria o conteúdo da mensagem de broadcast em JSON
                        var messageContent = new StringContent($"{{\"message\":\"{broadcastMessage}\"}}", Encoding.UTF8, "application/json");

                        // Faz a requisição POST para enviar a mensagem
                        var response = await client.PostAsync(apiUrl+ "announce", messageContent);

                        if (response.IsSuccessStatusCode)
                        {
                            // Se a resposta for bem-sucedida, salva o conteúdo da resposta
                            LogsTxt("Enviado Broadcast: " + broadcastMessage);
                        }
                        else
                        {
                            // Em caso de falha, salva o status e o conteúdo do erro
                            LogsTxt("Erro no envio" + response.Content);

                        }
                    }
                }
                catch (Exception ex)
                {
                    // Registra qualquer exceção
                    LogsTxt("Error: " + ex.Message);
                }
            }
            
        }


        public static void CleanTempFiles()
        {
            try
            {
                string[] tempFiles = { "curl_status.txt", "curl_output.txt", "response.json", "temp_error.json" };
                foreach (var file in tempFiles)
                {
                    string filePath = Path.Combine(baseDir, "Dados", file);
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                }
            }
            catch
            {  
            }


        }

        public static async Task<bool> MakeApiRequest(string apiUrl, string username, string password, string responseFile, string curlStatusFile, string curlOutputFile)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var authInfo = Convert.ToBase64String(Encoding.Default.GetBytes($"{username}:{password}"));
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authInfo);

                    var response = await client.GetAsync(apiUrl+"players");

                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        File.WriteAllText(responseFile, content);
                        return true;
                    }
                    else
                    {
                        var statusCode = (int)response.StatusCode;
                        File.WriteAllText(curlStatusFile, statusCode.ToString());
                        var errorContent = await response.Content.ReadAsStringAsync();
                        File.AppendAllText(Path.Combine(baseDir, "Dados", "logs", "logs.txt"), $"Falha na requisição à API. Código de status: {statusCode}\nDetalhes do erro:\n{errorContent}\n");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(Path.Combine(baseDir, "Dados", "logs", "logs.txt"), $"Erro na requisição à API: {ex.Message}\n");
                return false;
            }
        }



        private static void LogsTxt(string message)
        {
            if (txtLogs.InvokeRequired)
            {
                txtLogs.Invoke(new Action(() => txtLogs.AppendText(message + Environment.NewLine)));
            }
            else
            {
                txtLogs.AppendText(message + Environment.NewLine);
            }
        }


        class Player
        {
            public string Name { get; set; }
            public string AccountName { get; set; }
            public string PlayerId { get; set; }
            public int LocationX { get; set; }
            public int LocationY { get; set; }
        }





        private async void btnColetaLocal_Click(object sender, EventArgs e)
        {
            if (await MakeApiRequest(apiUrl, authUsername, authPassword, responseFile, curlStatusFile, curlOutputFile))
            {
                ColectCoordinate(playersCsvFile);
                if (string.IsNullOrWhiteSpace(tbFileLocationX.Text) || string.IsNullOrWhiteSpace(tbFileLocationY.Text))
                {
                    MessageBox.Show("As coordenadas X e Y devem ser preenchidas.");

                }
                else
                {
                    btnNotifyEvent.Enabled = true;
                }

            }
            else
            {
                LogsTxt($"Erro servidor offline");
            }
        }

        private void btnIgnoraPlayer_Click(object sender, EventArgs e)
        {
            var players = ReadPlayersFromCsv(playersCsvFile);
            string selectedPlayerName = lstPlayers.SelectedItem.ToString(); // ou comboBoxPlayers.SelectedItem.ToString()

            // Procurar o jogador correspondente na lista de players
            var selectedPlayer = players.FirstOrDefault(p => p.Name.Equals(selectedPlayerName, StringComparison.OrdinalIgnoreCase));

            if (selectedPlayer != null)
            {
                // Pegar as coordenadas do jogador
                //tbFileLocationX.Text = selectedPlayer.LocationX.ToString(); // Supondo que o item tenha uma propriedade X
                //tbFileLocationY.Text = selectedPlayer.LocationY.ToString(); // Supondo que o item tenha uma propriedade Y
                lbPlayersIgnorados.Items.Add(selectedPlayer.Name);
                LogsTxt($"Player {selectedPlayer.Name} ignorado!");

            }
            else
            {
                // Jogador não encontrado
                MessageBox.Show("Jogador não encontrado na lista.");
            }
        }

        private void btnLimparIgnorados_Click(object sender, EventArgs e)
        {
            lbPlayersIgnorados.Items.Clear();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Sevidor = txtServer.Text;
            Properties.Settings.Default.Senha = txtPassword.Text;

            if (int.TryParse(txtPort.Text, out int portaApi))
                Properties.Settings.Default.PortaApi = portaApi;

            Properties.Settings.Default.WebHookDiscord = tbDiscordWebHook.Text;
            Properties.Settings.Default.WebHookTeste = tbDiscordWebHookTeste.Text;
            Properties.Settings.Default.NomeTesouro = tbTesouroName.Text;
            Properties.Settings.Default.localizacaoX = tbFileLocationX.Text;
            Properties.Settings.Default.localizacaoY = tbFileLocationY.Text;
            

            if (float.TryParse(txtToleranciaProximaL.Text, out float muitoLonge))
                Properties.Settings.Default.MuitoLonge = muitoLonge;

            if (float.TryParse(txttoleranciaProximaM.Text, out float longe))
                Properties.Settings.Default.Longe = longe;

            if (float.TryParse(txtToleranciaProximaP.Text, out float perto))
                Properties.Settings.Default.Medio = perto;

            if (float.TryParse(txtToleranciaProximaMP.Text, out float muitoPerto))
                Properties.Settings.Default.Perto = muitoPerto;

            if (float.TryParse(txtToleranciaPerigo.Text, out float perigo))
                Properties.Settings.Default.MuitoPerto = perigo;

            // Salva as alterações nos settings
            Properties.Settings.Default.Save();
            _form2?.Close();

        }
        public void Form1_Load(object sender, EventArgs e)
        {

            InitializeDirectoriesAndFiles();

            baseDir = AppDomain.CurrentDomain.BaseDirectory;
            logsDir = Path.Combine(baseDir, @"Dados\logs");
            playersCsvFile = Path.Combine(baseDir, @"Dados\players_data.csv");
            responseFile = Path.Combine(baseDir, @"Dados\response.json");
            curlStatusFile = Path.Combine(baseDir, "Dados", "curl_status.txt");
            curlOutputFile = Path.Combine(baseDir, "Dados", "curl_output.txt");

            string[] tempFiles = { "curl_status.txt", "curl_output.txt", "response.json", "temp_error.json", "players_data.csv" };
            foreach (var file in tempFiles)
            {
                string filePath = Path.Combine(baseDir, "Dados", file);
                if (File.Exists(filePath))
                    File.Delete(filePath);
            }
            txtServer.Text = Properties.Settings.Default.Sevidor;
            txtPort.Text = Properties.Settings.Default.PortaApi.ToString();
            txtPassword.Text = Properties.Settings.Default.Senha.ToString();
            tbDiscordWebHook.Text = Properties.Settings.Default.WebHookDiscord;
            tbDiscordWebHookTeste.Text = Properties.Settings.Default.WebHookTeste;
            tbTesouroName.Text = Properties.Settings.Default.NomeTesouro;
            txtToleranciaProximaL.Text = Properties.Settings.Default.MuitoLonge.ToString();
            txttoleranciaProximaM.Text = Properties.Settings.Default.Longe.ToString();
            txtToleranciaProximaP.Text = Properties.Settings.Default.Medio.ToString();
            txtToleranciaProximaMP.Text = Properties.Settings.Default.Perto.ToString();
            txtToleranciaPerigo.Text = Properties.Settings.Default.MuitoPerto.ToString();
            tbFileLocationX.Text = Properties.Settings.Default.localizacaoX;
            tbFileLocationY.Text = Properties.Settings.Default.localizacaoY;
        }

        private async void btnEnviarMensagem_Click(object sender, EventArgs e)
        {
            btnEnviarMensagem.Enabled = false;
            discordWebhookUrl = tbDiscordWebHook.Text;
            if (cbTesteWebHook.Checked)
            {
                discordWebhookUrl = tbDiscordWebHookTeste.Text;
            }

            await SendDiscordNotification(tbMensagemWebHook.Text, discordWebhookUrl);
            await SendGlobalBroadcast(apiUrl, authUsername, authPassword, tbMensagemWebHook.Text);
            LogsTxt(tbMensagemWebHook.Text);
            tbMensagemWebHook.Clear();
            btnEnviarMensagem.Enabled = true;
        }
    }
}
