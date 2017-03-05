namespace ExtractTermo
{
    partial class DataSheets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tDescriereProdusLocal = new System.Windows.Forms.TextBox();
            this.lIdProdusLocal = new System.Windows.Forms.Label();
            this.tPaginaProducatorLocal = new System.Windows.Forms.TextBox();
            this.tDenumireProdusLocal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cVizibilLocal = new System.Windows.Forms.CheckBox();
            this.tDisplayOrderLocal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.bSaveLocal = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tStocLocal = new System.Windows.Forms.TextBox();
            this.webBrowserLocal = new System.Windows.Forms.WebBrowser();
            this.webBrowserNou = new System.Windows.Forms.WebBrowser();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tDenumireFisierServer = new System.Windows.Forms.TextBox();
            this.webBrowserServer = new System.Windows.Forms.WebBrowser();
            this.label12 = new System.Windows.Forms.Label();
            this.tDenumireFisierLocal = new System.Windows.Forms.TextBox();
            this.tDenumireFisierNouModificata = new System.Windows.Forms.TextBox();
            this.tDenumireFisierNou = new System.Windows.Forms.TextBox();
            this.nIncarca = new System.Windows.Forms.Button();
            this.bSavePeServer = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cCreazaFisaNoua = new System.Windows.Forms.CheckBox();
            this.bFisiereOrfane = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cToatePozeleServer = new System.Windows.Forms.CheckBox();
            this.bDeleteServer = new System.Windows.Forms.Button();
            this.bAddServer = new System.Windows.Forms.Button();
            this.tNewImgServer = new System.Windows.Forms.TextBox();
            this.bUndoServer = new System.Windows.Forms.Button();
            this.panelPozeServer = new System.Windows.Forms.Panel();
            this.bPreluarePeLocal = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tDenumireProdusServer = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lIdProdusServer = new System.Windows.Forms.Label();
            this.tStocServer = new System.Windows.Forms.TextBox();
            this.tDescriereProdusServer = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tDisplayOrderServer = new System.Windows.Forms.TextBox();
            this.tPaginaProducatorServer = new System.Windows.Forms.TextBox();
            this.cVizibilServer = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cToatePozeleLocal = new System.Windows.Forms.CheckBox();
            this.bDeleteLocal = new System.Windows.Forms.Button();
            this.bAddLocal = new System.Windows.Forms.Button();
            this.tNewImgLocal = new System.Windows.Forms.TextBox();
            this.bUndoLocal = new System.Windows.Forms.Button();
            this.panelPozeLocal = new System.Windows.Forms.Panel();
            this.bPreluarePeServer = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Actual local";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(544, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nou:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 8);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(335, 679);
            this.checkedListBox1.TabIndex = 11;
            this.checkedListBox1.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 693);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(335, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Actualizate x / y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tDescriereProdusLocal
            // 
            this.tDescriereProdusLocal.Location = new System.Drawing.Point(39, 75);
            this.tDescriereProdusLocal.Multiline = true;
            this.tDescriereProdusLocal.Name = "tDescriereProdusLocal";
            this.tDescriereProdusLocal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tDescriereProdusLocal.Size = new System.Drawing.Size(315, 152);
            this.tDescriereProdusLocal.TabIndex = 15;
            // 
            // lIdProdusLocal
            // 
            this.lIdProdusLocal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lIdProdusLocal.Location = new System.Drawing.Point(8, 36);
            this.lIdProdusLocal.Name = "lIdProdusLocal";
            this.lIdProdusLocal.Size = new System.Drawing.Size(25, 23);
            this.lIdProdusLocal.TabIndex = 16;
            this.lIdProdusLocal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tPaginaProducatorLocal
            // 
            this.tPaginaProducatorLocal.Location = new System.Drawing.Point(40, 246);
            this.tPaginaProducatorLocal.Name = "tPaginaProducatorLocal";
            this.tPaginaProducatorLocal.Size = new System.Drawing.Size(315, 20);
            this.tPaginaProducatorLocal.TabIndex = 17;
            // 
            // tDenumireProdusLocal
            // 
            this.tDenumireProdusLocal.Location = new System.Drawing.Point(39, 36);
            this.tDenumireProdusLocal.Name = "tDenumireProdusLocal";
            this.tDenumireProdusLocal.Size = new System.Drawing.Size(315, 20);
            this.tDenumireProdusLocal.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(39, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Denumire produs:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(40, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Pagina producator:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cVizibilLocal
            // 
            this.cVizibilLocal.AutoSize = true;
            this.cVizibilLocal.BackColor = System.Drawing.Color.Transparent;
            this.cVizibilLocal.Location = new System.Drawing.Point(40, 281);
            this.cVizibilLocal.Name = "cVizibilLocal";
            this.cVizibilLocal.Size = new System.Drawing.Size(52, 17);
            this.cVizibilLocal.TabIndex = 21;
            this.cVizibilLocal.Text = "Vizibil";
            this.cVizibilLocal.UseVisualStyleBackColor = false;
            // 
            // tDisplayOrderLocal
            // 
            this.tDisplayOrderLocal.Location = new System.Drawing.Point(199, 279);
            this.tDisplayOrderLocal.Name = "tDisplayOrderLocal";
            this.tDisplayOrderLocal.Size = new System.Drawing.Size(27, 20);
            this.tDisplayOrderLocal.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(126, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Display order:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bSaveLocal
            // 
            this.bSaveLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bSaveLocal.AutoSize = true;
            this.bSaveLocal.Location = new System.Drawing.Point(347, 630);
            this.bSaveLocal.Name = "bSaveLocal";
            this.bSaveLocal.Size = new System.Drawing.Size(80, 23);
            this.bSaveLocal.TabIndex = 24;
            this.bSaveLocal.Text = "Salvare";
            this.bSaveLocal.UseVisualStyleBackColor = true;
            this.bSaveLocal.Click += new System.EventHandler(this.button4_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(256, 282);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "Stoc:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tStocLocal
            // 
            this.tStocLocal.Location = new System.Drawing.Point(291, 279);
            this.tStocLocal.Name = "tStocLocal";
            this.tStocLocal.Size = new System.Drawing.Size(27, 20);
            this.tStocLocal.TabIndex = 27;
            // 
            // webBrowserLocal
            // 
            this.webBrowserLocal.Location = new System.Drawing.Point(6, 19);
            this.webBrowserLocal.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserLocal.Name = "webBrowserLocal";
            this.webBrowserLocal.Size = new System.Drawing.Size(250, 330);
            this.webBrowserLocal.TabIndex = 29;
            // 
            // webBrowserNou
            // 
            this.webBrowserNou.Location = new System.Drawing.Point(544, 19);
            this.webBrowserNou.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserNou.Name = "webBrowserNou";
            this.webBrowserNou.Size = new System.Drawing.Size(250, 330);
            this.webBrowserNou.TabIndex = 30;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(353, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(808, 694);
            this.tabControl1.TabIndex = 31;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.tDenumireFisierServer);
            this.tabPage1.Controls.Add(this.webBrowserServer);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.tDenumireFisierLocal);
            this.tabPage1.Controls.Add(this.tDenumireFisierNouModificata);
            this.tabPage1.Controls.Add(this.tDenumireFisierNou);
            this.tabPage1.Controls.Add(this.nIncarca);
            this.tabPage1.Controls.Add(this.bSavePeServer);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cCreazaFisaNoua);
            this.tabPage1.Controls.Add(this.bFisiereOrfane);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.webBrowserNou);
            this.tabPage1.Controls.Add(this.webBrowserLocal);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(800, 668);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Fisiere";
            // 
            // tDenumireFisierServer
            // 
            this.tDenumireFisierServer.Location = new System.Drawing.Point(273, 355);
            this.tDenumireFisierServer.Name = "tDenumireFisierServer";
            this.tDenumireFisierServer.ReadOnly = true;
            this.tDenumireFisierServer.Size = new System.Drawing.Size(250, 20);
            this.tDenumireFisierServer.TabIndex = 41;
            // 
            // webBrowserServer
            // 
            this.webBrowserServer.Location = new System.Drawing.Point(273, 19);
            this.webBrowserServer.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserServer.Name = "webBrowserServer";
            this.webBrowserServer.Size = new System.Drawing.Size(250, 330);
            this.webBrowserServer.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(273, 3);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Actual server";
            // 
            // tDenumireFisierLocal
            // 
            this.tDenumireFisierLocal.Location = new System.Drawing.Point(6, 355);
            this.tDenumireFisierLocal.Name = "tDenumireFisierLocal";
            this.tDenumireFisierLocal.ReadOnly = true;
            this.tDenumireFisierLocal.Size = new System.Drawing.Size(250, 20);
            this.tDenumireFisierLocal.TabIndex = 31;
            // 
            // tDenumireFisierNouModificata
            // 
            this.tDenumireFisierNouModificata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tDenumireFisierNouModificata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tDenumireFisierNouModificata.Location = new System.Drawing.Point(544, 396);
            this.tDenumireFisierNouModificata.Name = "tDenumireFisierNouModificata";
            this.tDenumireFisierNouModificata.Size = new System.Drawing.Size(250, 20);
            this.tDenumireFisierNouModificata.TabIndex = 32;
            // 
            // tDenumireFisierNou
            // 
            this.tDenumireFisierNou.Location = new System.Drawing.Point(544, 357);
            this.tDenumireFisierNou.Name = "tDenumireFisierNou";
            this.tDenumireFisierNou.ReadOnly = true;
            this.tDenumireFisierNou.Size = new System.Drawing.Size(223, 20);
            this.tDenumireFisierNou.TabIndex = 33;
            // 
            // nIncarca
            // 
            this.nIncarca.Location = new System.Drawing.Point(770, 357);
            this.nIncarca.Name = "nIncarca";
            this.nIncarca.Size = new System.Drawing.Size(24, 23);
            this.nIncarca.TabIndex = 34;
            this.nIncarca.Text = "...";
            this.nIncarca.UseVisualStyleBackColor = true;
            this.nIncarca.Click += new System.EventHandler(this.nIncarca_Click);
            // 
            // bSavePeServer
            // 
            this.bSavePeServer.Enabled = false;
            this.bSavePeServer.Location = new System.Drawing.Point(661, 422);
            this.bSavePeServer.Name = "bSavePeServer";
            this.bSavePeServer.Size = new System.Drawing.Size(133, 23);
            this.bSavePeServer.TabIndex = 35;
            this.bSavePeServer.Text = "Salveaza";
            this.bSavePeServer.UseVisualStyleBackColor = true;
            this.bSavePeServer.Click += new System.EventHandler(this.bSavePeServer_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 380);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Denumire noua:";
            // 
            // cCreazaFisaNoua
            // 
            this.cCreazaFisaNoua.AutoSize = true;
            this.cCreazaFisaNoua.Enabled = false;
            this.cCreazaFisaNoua.Location = new System.Drawing.Point(544, 426);
            this.cCreazaFisaNoua.Name = "cCreazaFisaNoua";
            this.cCreazaFisaNoua.Size = new System.Drawing.Size(105, 17);
            this.cCreazaFisaNoua.TabIndex = 37;
            this.cCreazaFisaNoua.Text = "Creaza fisa noua";
            this.cCreazaFisaNoua.UseVisualStyleBackColor = true;
            // 
            // bFisiereOrfane
            // 
            this.bFisiereOrfane.AutoSize = true;
            this.bFisiereOrfane.Location = new System.Drawing.Point(661, 549);
            this.bFisiereOrfane.Name = "bFisiereOrfane";
            this.bFisiereOrfane.Size = new System.Drawing.Size(80, 23);
            this.bFisiereOrfane.TabIndex = 38;
            this.bFisiereOrfane.Text = "Fisiere orfane";
            this.bFisiereOrfane.UseVisualStyleBackColor = true;
            this.bFisiereOrfane.Click += new System.EventHandler(this.bFisiereOrfane_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.bSaveLocal);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(800, 668);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Informatii";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Pink;
            this.groupBox2.Controls.Add(this.cToatePozeleServer);
            this.groupBox2.Controls.Add(this.bDeleteServer);
            this.groupBox2.Controls.Add(this.bAddServer);
            this.groupBox2.Controls.Add(this.tNewImgServer);
            this.groupBox2.Controls.Add(this.bUndoServer);
            this.groupBox2.Controls.Add(this.panelPozeServer);
            this.groupBox2.Controls.Add(this.bPreluarePeLocal);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.tDenumireProdusServer);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.lIdProdusServer);
            this.groupBox2.Controls.Add(this.tStocServer);
            this.groupBox2.Controls.Add(this.tDescriereProdusServer);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tDisplayOrderServer);
            this.groupBox2.Controls.Add(this.tPaginaProducatorServer);
            this.groupBox2.Controls.Add(this.cVizibilServer);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(382, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(365, 609);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "SERVER";
            // 
            // cToatePozeleServer
            // 
            this.cToatePozeleServer.AutoSize = true;
            this.cToatePozeleServer.BackColor = System.Drawing.SystemColors.Control;
            this.cToatePozeleServer.Location = new System.Drawing.Point(10, 519);
            this.cToatePozeleServer.Name = "cToatePozeleServer";
            this.cToatePozeleServer.Size = new System.Drawing.Size(15, 14);
            this.cToatePozeleServer.TabIndex = 52;
            this.cToatePozeleServer.UseVisualStyleBackColor = false;
            this.cToatePozeleServer.CheckedChanged += new System.EventHandler(this.cToatePozeleServer_CheckedChanged);
            // 
            // bDeleteServer
            // 
            this.bDeleteServer.AutoSize = true;
            this.bDeleteServer.Location = new System.Drawing.Point(328, 514);
            this.bDeleteServer.Name = "bDeleteServer";
            this.bDeleteServer.Size = new System.Drawing.Size(26, 23);
            this.bDeleteServer.TabIndex = 51;
            this.bDeleteServer.Text = "-";
            this.bDeleteServer.UseVisualStyleBackColor = true;
            this.bDeleteServer.Click += new System.EventHandler(this.bDeleteServer_Click);
            // 
            // bAddServer
            // 
            this.bAddServer.AutoSize = true;
            this.bAddServer.Location = new System.Drawing.Point(296, 514);
            this.bAddServer.Name = "bAddServer";
            this.bAddServer.Size = new System.Drawing.Size(26, 23);
            this.bAddServer.TabIndex = 50;
            this.bAddServer.Text = "+";
            this.bAddServer.UseVisualStyleBackColor = true;
            this.bAddServer.Click += new System.EventHandler(this.bAddServer_Click);
            // 
            // tNewImgServer
            // 
            this.tNewImgServer.Location = new System.Drawing.Point(41, 516);
            this.tNewImgServer.Name = "tNewImgServer";
            this.tNewImgServer.Size = new System.Drawing.Size(249, 20);
            this.tNewImgServer.TabIndex = 49;
            // 
            // bUndoServer
            // 
            this.bUndoServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bUndoServer.AutoSize = true;
            this.bUndoServer.Location = new System.Drawing.Point(144, 575);
            this.bUndoServer.Name = "bUndoServer";
            this.bUndoServer.Size = new System.Drawing.Size(26, 23);
            this.bUndoServer.TabIndex = 46;
            this.bUndoServer.Text = "<-";
            this.bUndoServer.UseVisualStyleBackColor = true;
            this.bUndoServer.Click += new System.EventHandler(this.bUndoServer_Click);
            // 
            // panelPozeServer
            // 
            this.panelPozeServer.AutoScroll = true;
            this.panelPozeServer.Location = new System.Drawing.Point(7, 304);
            this.panelPozeServer.Name = "panelPozeServer";
            this.panelPozeServer.Size = new System.Drawing.Size(346, 206);
            this.panelPozeServer.TabIndex = 45;
            // 
            // bPreluarePeLocal
            // 
            this.bPreluarePeLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bPreluarePeLocal.AutoSize = true;
            this.bPreluarePeLocal.Location = new System.Drawing.Point(7, 575);
            this.bPreluarePeLocal.Name = "bPreluarePeLocal";
            this.bPreluarePeLocal.Size = new System.Drawing.Size(131, 23);
            this.bPreluarePeLocal.TabIndex = 42;
            this.bPreluarePeLocal.Text = "<< Preluare pe local";
            this.bPreluarePeLocal.UseVisualStyleBackColor = true;
            this.bPreluarePeLocal.Click += new System.EventHandler(this.bPreluarePeLocal_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Descriere produs:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tDenumireProdusServer
            // 
            this.tDenumireProdusServer.Location = new System.Drawing.Point(38, 35);
            this.tDenumireProdusServer.Name = "tDenumireProdusServer";
            this.tDenumireProdusServer.Size = new System.Drawing.Size(315, 20);
            this.tDenumireProdusServer.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(255, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Stoc:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lIdProdusServer
            // 
            this.lIdProdusServer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lIdProdusServer.Location = new System.Drawing.Point(7, 35);
            this.lIdProdusServer.Name = "lIdProdusServer";
            this.lIdProdusServer.Size = new System.Drawing.Size(25, 23);
            this.lIdProdusServer.TabIndex = 30;
            this.lIdProdusServer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tStocServer
            // 
            this.tStocServer.Location = new System.Drawing.Point(290, 278);
            this.tStocServer.Name = "tStocServer";
            this.tStocServer.Size = new System.Drawing.Size(27, 20);
            this.tStocServer.TabIndex = 40;
            // 
            // tDescriereProdusServer
            // 
            this.tDescriereProdusServer.Location = new System.Drawing.Point(38, 74);
            this.tDescriereProdusServer.Multiline = true;
            this.tDescriereProdusServer.Name = "tDescriereProdusServer";
            this.tDescriereProdusServer.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tDescriereProdusServer.Size = new System.Drawing.Size(315, 152);
            this.tDescriereProdusServer.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(38, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(90, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "Denumire produs:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(125, 281);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(71, 13);
            this.label14.TabIndex = 38;
            this.label14.Text = "Display order:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(39, 229);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(97, 13);
            this.label15.TabIndex = 35;
            this.label15.Text = "Pagina producator:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tDisplayOrderServer
            // 
            this.tDisplayOrderServer.Location = new System.Drawing.Point(198, 278);
            this.tDisplayOrderServer.Name = "tDisplayOrderServer";
            this.tDisplayOrderServer.Size = new System.Drawing.Size(27, 20);
            this.tDisplayOrderServer.TabIndex = 37;
            // 
            // tPaginaProducatorServer
            // 
            this.tPaginaProducatorServer.Location = new System.Drawing.Point(39, 245);
            this.tPaginaProducatorServer.Name = "tPaginaProducatorServer";
            this.tPaginaProducatorServer.Size = new System.Drawing.Size(315, 20);
            this.tPaginaProducatorServer.TabIndex = 31;
            // 
            // cVizibilServer
            // 
            this.cVizibilServer.AutoSize = true;
            this.cVizibilServer.BackColor = System.Drawing.Color.Transparent;
            this.cVizibilServer.Location = new System.Drawing.Point(39, 280);
            this.cVizibilServer.Name = "cVizibilServer";
            this.cVizibilServer.Size = new System.Drawing.Size(52, 17);
            this.cVizibilServer.TabIndex = 36;
            this.cVizibilServer.Text = "Vizibil";
            this.cVizibilServer.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.groupBox1.Controls.Add(this.cToatePozeleLocal);
            this.groupBox1.Controls.Add(this.bDeleteLocal);
            this.groupBox1.Controls.Add(this.bAddLocal);
            this.groupBox1.Controls.Add(this.tNewImgLocal);
            this.groupBox1.Controls.Add(this.bUndoLocal);
            this.groupBox1.Controls.Add(this.panelPozeLocal);
            this.groupBox1.Controls.Add(this.bPreluarePeServer);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tDenumireProdusLocal);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.lIdProdusLocal);
            this.groupBox1.Controls.Add(this.tStocLocal);
            this.groupBox1.Controls.Add(this.tDescriereProdusLocal);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.tDisplayOrderLocal);
            this.groupBox1.Controls.Add(this.tPaginaProducatorLocal);
            this.groupBox1.Controls.Add(this.cVizibilLocal);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 609);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LOCAL";
            // 
            // cToatePozeleLocal
            // 
            this.cToatePozeleLocal.AutoSize = true;
            this.cToatePozeleLocal.BackColor = System.Drawing.SystemColors.Control;
            this.cToatePozeleLocal.Enabled = false;
            this.cToatePozeleLocal.Location = new System.Drawing.Point(8, 518);
            this.cToatePozeleLocal.Name = "cToatePozeleLocal";
            this.cToatePozeleLocal.Size = new System.Drawing.Size(15, 14);
            this.cToatePozeleLocal.TabIndex = 49;
            this.cToatePozeleLocal.UseVisualStyleBackColor = false;
            this.cToatePozeleLocal.CheckedChanged += new System.EventHandler(this.cToatePozeleLocal_CheckedChanged);
            // 
            // bDeleteLocal
            // 
            this.bDeleteLocal.AutoSize = true;
            this.bDeleteLocal.Enabled = false;
            this.bDeleteLocal.Location = new System.Drawing.Point(326, 514);
            this.bDeleteLocal.Name = "bDeleteLocal";
            this.bDeleteLocal.Size = new System.Drawing.Size(26, 23);
            this.bDeleteLocal.TabIndex = 48;
            this.bDeleteLocal.Text = "-";
            this.bDeleteLocal.UseVisualStyleBackColor = true;
            this.bDeleteLocal.Click += new System.EventHandler(this.bDeleteLocal_Click);
            // 
            // bAddLocal
            // 
            this.bAddLocal.AutoSize = true;
            this.bAddLocal.Enabled = false;
            this.bAddLocal.Location = new System.Drawing.Point(294, 514);
            this.bAddLocal.Name = "bAddLocal";
            this.bAddLocal.Size = new System.Drawing.Size(26, 23);
            this.bAddLocal.TabIndex = 47;
            this.bAddLocal.Text = "+";
            this.bAddLocal.UseVisualStyleBackColor = true;
            this.bAddLocal.Click += new System.EventHandler(this.bAddLocal_Click);
            // 
            // tNewImgLocal
            // 
            this.tNewImgLocal.Enabled = false;
            this.tNewImgLocal.Location = new System.Drawing.Point(42, 516);
            this.tNewImgLocal.Name = "tNewImgLocal";
            this.tNewImgLocal.Size = new System.Drawing.Size(246, 20);
            this.tNewImgLocal.TabIndex = 46;
            // 
            // bUndoLocal
            // 
            this.bUndoLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bUndoLocal.AutoSize = true;
            this.bUndoLocal.Location = new System.Drawing.Point(190, 575);
            this.bUndoLocal.Name = "bUndoLocal";
            this.bUndoLocal.Size = new System.Drawing.Size(26, 23);
            this.bUndoLocal.TabIndex = 45;
            this.bUndoLocal.Text = "->";
            this.bUndoLocal.UseVisualStyleBackColor = true;
            this.bUndoLocal.Click += new System.EventHandler(this.bUndoLocal_Click);
            // 
            // panelPozeLocal
            // 
            this.panelPozeLocal.AutoScroll = true;
            this.panelPozeLocal.Location = new System.Drawing.Point(8, 305);
            this.panelPozeLocal.Name = "panelPozeLocal";
            this.panelPozeLocal.Size = new System.Drawing.Size(346, 205);
            this.panelPozeLocal.TabIndex = 44;
            // 
            // bPreluarePeServer
            // 
            this.bPreluarePeServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bPreluarePeServer.AutoSize = true;
            this.bPreluarePeServer.Location = new System.Drawing.Point(222, 575);
            this.bPreluarePeServer.Name = "bPreluarePeServer";
            this.bPreluarePeServer.Size = new System.Drawing.Size(139, 23);
            this.bPreluarePeServer.TabIndex = 43;
            this.bPreluarePeServer.Text = "Preluare pe server >>";
            this.bPreluarePeServer.UseVisualStyleBackColor = true;
            this.bPreluarePeServer.Click += new System.EventHandler(this.bPreluarePeServer_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(39, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Descriere produs:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataSheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 715);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkedListBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "DataSheets";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.DataSheets_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tDescriereProdusLocal;
        private System.Windows.Forms.Label lIdProdusLocal;
        private System.Windows.Forms.TextBox tPaginaProducatorLocal;
        private System.Windows.Forms.TextBox tDenumireProdusLocal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cVizibilLocal;
        private System.Windows.Forms.TextBox tDisplayOrderLocal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button bSaveLocal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tStocLocal;
        private System.Windows.Forms.WebBrowser webBrowserLocal;
        private System.Windows.Forms.WebBrowser webBrowserNou;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tDenumireFisierLocal;
        private System.Windows.Forms.TextBox tDenumireFisierNouModificata;
        private System.Windows.Forms.TextBox tDenumireFisierNou;
        private System.Windows.Forms.Button nIncarca;
        private System.Windows.Forms.Button bSavePeServer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cCreazaFisaNoua;
        private System.Windows.Forms.Button bFisiereOrfane;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tDenumireProdusServer;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lIdProdusServer;
        private System.Windows.Forms.TextBox tStocServer;
        private System.Windows.Forms.TextBox tDescriereProdusServer;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tDisplayOrderServer;
        private System.Windows.Forms.TextBox tPaginaProducatorServer;
        private System.Windows.Forms.CheckBox cVizibilServer;
        private System.Windows.Forms.Button bPreluarePeLocal;
        private System.Windows.Forms.Button bPreluarePeServer;
        private System.Windows.Forms.TextBox tDenumireFisierServer;
        private System.Windows.Forms.WebBrowser webBrowserServer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelPozeServer;
        private System.Windows.Forms.Panel panelPozeLocal;
        private System.Windows.Forms.Button bUndoServer;
        private System.Windows.Forms.Button bUndoLocal;
        private System.Windows.Forms.Button bDeleteLocal;
        private System.Windows.Forms.Button bAddLocal;
        private System.Windows.Forms.TextBox tNewImgLocal;
        private System.Windows.Forms.Button bDeleteServer;
        private System.Windows.Forms.Button bAddServer;
        private System.Windows.Forms.TextBox tNewImgServer;
        private System.Windows.Forms.CheckBox cToatePozeleServer;
        private System.Windows.Forms.CheckBox cToatePozeleLocal;
    }
}