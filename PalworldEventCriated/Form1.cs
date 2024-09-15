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
        public Form1()
        {
            InitializeComponent();
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
            cbTesteWebHook = new CheckBox();
            label11 = new Label();
            textBox7 = new TextBox();
            label10 = new Label();
            textBox6 = new TextBox();
            label9 = new Label();
            textBox5 = new TextBox();
            label8 = new Label();
            textBox4 = new TextBox();
            label7 = new Label();
            textBox3 = new TextBox();
            label6 = new Label();
            listBox1 = new ListBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            tbDiscordWebHookTeste = new TextBox();
            label1 = new Label();
            tbDiscordWebHook = new TextBox();
            ControleDePonto = new TabPage();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            pictureBox1 = new PictureBox();
            tabControl1.SuspendLayout();
            QuenteFrio.SuspendLayout();
            ControleDePonto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblServer
            // 
            lblServer.AutoSize = true;
            lblServer.Location = new Point(20, 28);
            lblServer.Name = "lblServer";
            lblServer.Size = new Size(53, 15);
            lblServer.TabIndex = 0;
            lblServer.Text = "Servidor:";
            // 
            // txtServer
            // 
            txtServer.Location = new Point(79, 20);
            txtServer.Name = "txtServer";
            txtServer.Size = new Size(150, 23);
            txtServer.TabIndex = 1;
            txtServer.Text = "192.168.100.73";
            // 
            // lblPort
            // 
            lblPort.AutoSize = true;
            lblPort.Location = new Point(248, 28);
            lblPort.Name = "lblPort";
            lblPort.Size = new Size(59, 15);
            lblPort.TabIndex = 2;
            lblPort.Text = "Porta Api:";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(313, 20);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(92, 23);
            txtPort.TabIndex = 3;
            txtPort.Text = "8212";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(427, 28);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(42, 15);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Senha:";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(475, 20);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(106, 23);
            txtPassword.TabIndex = 5;
            txtPassword.Text = "unreal";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(606, 20);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(100, 23);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Conectar";
            btnConnect.Click += BtnConnect_Click;
            // 
            // btnNotifyEvent
            // 
            btnNotifyEvent.Enabled = false;
            btnNotifyEvent.Location = new Point(432, 316);
            btnNotifyEvent.Name = "btnNotifyEvent";
            btnNotifyEvent.Size = new Size(100, 30);
            btnNotifyEvent.TabIndex = 7;
            btnNotifyEvent.Text = "Iniciar Evento";
            btnNotifyEvent.Click += BtnNotifyEvent_Click;
            // 
            // lstPlayers
            // 
            lstPlayers.ItemHeight = 15;
            lstPlayers.Location = new Point(679, 140);
            lstPlayers.Name = "lstPlayers";
            lstPlayers.Size = new Size(242, 364);
            lstPlayers.TabIndex = 8;
            // 
            // txtLogs
            // 
            txtLogs.Location = new Point(20, 571);
            txtLogs.Multiline = true;
            txtLogs.Name = "txtLogs";
            txtLogs.ReadOnly = true;
            txtLogs.Size = new Size(557, 100);
            txtLogs.TabIndex = 9;
            // 
            // lblPlayers
            // 
            lblPlayers.AutoSize = true;
            lblPlayers.Location = new Point(679, 120);
            lblPlayers.Name = "lblPlayers";
            lblPlayers.Size = new Size(129, 15);
            lblPlayers.TabIndex = 10;
            lblPlayers.Text = "Jogadores Conectados:";
            // 
            // lblLogs
            // 
            lblLogs.AutoSize = true;
            lblLogs.Location = new Point(20, 551);
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
            tabControl1.Size = new Size(561, 387);
            tabControl1.TabIndex = 12;
            // 
            // QuenteFrio
            // 
            QuenteFrio.Controls.Add(cbTesteWebHook);
            QuenteFrio.Controls.Add(label11);
            QuenteFrio.Controls.Add(textBox7);
            QuenteFrio.Controls.Add(label10);
            QuenteFrio.Controls.Add(textBox6);
            QuenteFrio.Controls.Add(label9);
            QuenteFrio.Controls.Add(textBox5);
            QuenteFrio.Controls.Add(label8);
            QuenteFrio.Controls.Add(textBox4);
            QuenteFrio.Controls.Add(label7);
            QuenteFrio.Controls.Add(textBox3);
            QuenteFrio.Controls.Add(label6);
            QuenteFrio.Controls.Add(listBox1);
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
            QuenteFrio.Size = new Size(553, 359);
            QuenteFrio.TabIndex = 2;
            QuenteFrio.Text = "Quente e Frio";
            QuenteFrio.UseVisualStyleBackColor = true;
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
            label11.Location = new Point(16, 150);
            label11.Name = "label11";
            label11.Size = new Size(75, 15);
            label11.TabIndex = 25;
            label11.Text = "Muito Longe";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(92, 142);
            textBox7.Name = "textBox7";
            textBox7.PasswordChar = '*';
            textBox7.Size = new Size(73, 23);
            textBox7.TabIndex = 26;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(16, 266);
            label10.Name = "label10";
            label10.Size = new Size(70, 15);
            label10.TabIndex = 23;
            label10.Text = "Muito Perto";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(92, 258);
            textBox6.Name = "textBox6";
            textBox6.PasswordChar = '*';
            textBox6.Size = new Size(73, 23);
            textBox6.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(51, 237);
            label9.Name = "label9";
            label9.Size = new Size(35, 15);
            label9.TabIndex = 21;
            label9.Text = "Perto";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(92, 229);
            textBox5.Name = "textBox5";
            textBox5.PasswordChar = '*';
            textBox5.Size = new Size(73, 23);
            textBox5.TabIndex = 22;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(45, 208);
            label8.Name = "label8";
            label8.Size = new Size(41, 15);
            label8.TabIndex = 19;
            label8.Text = "Médio";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(92, 200);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(73, 23);
            textBox4.TabIndex = 20;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(46, 179);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 17;
            label7.Text = "Longe";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(92, 171);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(73, 23);
            textBox3.TabIndex = 18;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(403, 112);
            label6.Name = "label6";
            label6.Size = new Size(116, 15);
            label6.TabIndex = 14;
            label6.Text = "Jogadores Ignorados";
            // 
            // listBox1
            // 
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(403, 130);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(129, 154);
            listBox1.TabIndex = 16;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(7, 331);
            label4.Name = "label4";
            label4.Size = new Size(98, 15);
            label4.TabIndex = 15;
            label4.Text = "Localização em Y";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 310);
            label3.Name = "label3";
            label3.Size = new Size(98, 15);
            label3.TabIndex = 14;
            label3.Text = "Localização em X";
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
            ControleDePonto.Size = new Size(553, 359);
            ControleDePonto.TabIndex = 3;
            ControleDePonto.Text = "Controle de Ponto";
            ControleDePonto.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(191, 159);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 14;
            label5.Text = "Servidor:";
            // 
            // button1
            // 
            button1.Location = new Point(679, 510);
            button1.Name = "button1";
            button1.Size = new Size(103, 43);
            button1.TabIndex = 13;
            button1.Text = "Coletar localização";
            // 
            // button2
            // 
            button2.Location = new Point(826, 510);
            button2.Name = "button2";
            button2.Size = new Size(91, 43);
            button2.TabIndex = 14;
            button2.Text = "Ignorar jogador";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(757, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 85);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            ClientSize = new Size(929, 744);
            Controls.Add(pictureBox1);
            Controls.Add(button2);
            Controls.Add(button1);
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
            Name = "Form1";
            Text = "Conexão com Servidor de Eventos";
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
                apiUrl = $"http://{server}:{port}/v1/api/players";

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
                        btnNotifyEvent.Enabled = true;
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
                    lstPlayers.Items.Clear();
                }));
            }
        }


        private async void BtnNotifyEvent_Click(object sender, EventArgs e)
        {
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
                    while (isRunning)
                    {
                        CheckCoordinatesInTextFiles(playersCsvFile, directoryPath);
                        Task.Delay(1000).Wait(); // Intervalo de 1 segundo para evitar loop constante
                    }
                });
            }
            else
            {
                CleanTempFiles();
                isRunning = false;
                btnNotifyEvent.Text = "Iniciar Evento";
                btnConnect.Enabled = true;
                LogsTxt("Evento Parado!");
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDirectoriesAndFiles();
            
        }


        public void CheckCoordinatesInTextFiles(string playersCsvFile, string directoryPath)
        {
            try
            {
                var players = ReadPlayersFromCsv(playersCsvFile);
                var textFiles = Directory.GetFiles(directoryPath, "*.txt");

                foreach (var file in textFiles)
                {
                    var lines = File.ReadAllLines(file);
                    if (lines.Length < 1) continue;

                    var treasureData = lines[0].Split(',');
                    if (treasureData.Length < 4) continue;

                    string fileName = treasureData[0];
                    string fileAccountName = treasureData[1];
                    int fileLocationX = int.Parse(treasureData[2]);
                    int fileLocationY = int.Parse(treasureData[3]);

                    var ignoredPlayers = new HashSet<string>();
                    for (int i = 1; i < lines.Length; i++)
                    {
                        ignoredPlayers.Add(lines[i].Trim());
                    }

                    //LogsTxt($"Checking file: {Path.GetFileNameWithoutExtension(file)}");
                    //LogsTxt($"Ignored players: {string.Join(", ", ignoredPlayers)}");

                    foreach (var player in players)
                    {
                        if (ignoredPlayers.Contains(player.Name))
                        {
                            //LogsTxt($"Player {player.Name} foi ignorado");
                            continue;
                        }

                        int distanceX = Math.Abs(player.LocationX - fileLocationX);
                        int distanceY = Math.Abs(player.LocationY - fileLocationY);

                        string currentStatus = GetProximityStatus(distanceX, distanceY);
                        string playerKey = $"{player.AccountName}_{fileName}";

                        if (!lastProximityStatus.ContainsKey(playerKey) || lastProximityStatus[playerKey] != currentStatus)
                        {
                            SendProximityAlert(player, file, currentStatus);
                            lastProximityStatus[playerKey] = currentStatus;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                LogsTxt($"Erro ao verificar coordenadas: {ex.Message}");
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

        static void SendProximityAlert(Player player, string file, string message)
        {
            if (message != null)
            {
                string formattedMessage = $"{player.Name} {message} do {Path.GetFileNameWithoutExtension(file)}!";
                LogsTxt(formattedMessage);

                SendDiscordNotification(formattedMessage, discordWebhookUrl);
                if (!eventoDisponivel)
                {
                    SendDiscordNotification("############### Fim do evento ###############", discordWebhookUrl);
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

        public static void CleanTempFiles()
        {
            string[] tempFiles = { "curl_status.txt", "curl_output.txt", "response.json", "temp_error.json" };
            foreach (var file in tempFiles)
            {
                string filePath = Path.Combine(baseDir, "Dados", file);
                if (File.Exists(filePath))
                    File.Delete(filePath);
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

                    var response = await client.GetAsync(apiUrl);

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


    }
}
