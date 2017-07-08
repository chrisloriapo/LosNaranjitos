namespace LosNaranjitos.DS
{
    partial class FrmConfiguracion
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
            this.btnNext = new System.Windows.Forms.Button();
            this.lblValidEmail = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtApellido2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIdPersonal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbUtilitarios = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lblContrasenas = new System.Windows.Forms.Label();
            this.txtContrasenaConfirmada = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblValidMailDeliverer = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMailDeliverer = new System.Windows.Forms.TextBox();
            this.txtPortNumber = new System.Windows.Forms.TextBox();
            this.txtSmtp = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtPuerto = new System.Windows.Forms.Label();
            this.chkLuegoPrinter = new System.Windows.Forms.CheckBox();
            this.cbbImpresora = new System.Windows.Forms.ComboBox();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbMain = new System.Windows.Forms.TabControl();
            this.tbConexión = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cmbInstancias = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.rbSqlServer = new System.Windows.Forms.RadioButton();
            this.rbtWindosAut = new System.Windows.Forms.RadioButton();
            this.tbDatos = new System.Windows.Forms.TabPage();
            this.tbUtilitarios.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.tbConexión.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.tbDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(491, 446);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(95, 41);
            this.btnNext.TabIndex = 406;
            this.btnNext.Text = "Continuar";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblValidEmail
            // 
            this.lblValidEmail.AutoSize = true;
            this.lblValidEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValidEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblValidEmail.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidEmail.ForeColor = System.Drawing.Color.Red;
            this.lblValidEmail.Location = new System.Drawing.Point(336, 401);
            this.lblValidEmail.Name = "lblValidEmail";
            this.lblValidEmail.Size = new System.Drawing.Size(101, 17);
            this.lblValidEmail.TabIndex = 405;
            this.lblValidEmail.Text = "Email No Válido";
            this.lblValidEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(228, 234);
            this.txtTelefono.Mask = "(###)-####-####";
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(116, 26);
            this.txtTelefono.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(36, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 15);
            this.label9.TabIndex = 403;
            this.label9.Text = "Telefono";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(228, 107);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(338, 26);
            this.txtNombre.TabIndex = 2;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(228, 150);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(338, 26);
            this.txtApellido.TabIndex = 3;
            // 
            // txtApellido2
            // 
            this.txtApellido2.Location = new System.Drawing.Point(228, 193);
            this.txtApellido2.Name = "txtApellido2";
            this.txtApellido2.Size = new System.Drawing.Size(338, 26);
            this.txtApellido2.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 278);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 401;
            this.label7.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(228, 278);
            this.txtDireccion.Multiline = true;
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDireccion.Size = new System.Drawing.Size(338, 58);
            this.txtDireccion.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label8.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(36, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 15);
            this.label8.TabIndex = 393;
            this.label8.Text = "Id Personal";
            // 
            // txtIdPersonal
            // 
            this.txtIdPersonal.Location = new System.Drawing.Point(227, 75);
            this.txtIdPersonal.Name = "txtIdPersonal";
            this.txtIdPersonal.Size = new System.Drawing.Size(210, 26);
            this.txtIdPersonal.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(36, 361);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 15);
            this.label10.TabIndex = 398;
            this.label10.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(228, 361);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(338, 26);
            this.txtEmail.TabIndex = 7;
            this.txtEmail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmail_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(138, 20);
            this.label5.TabIndex = 5;
            this.label5.Text = "Segundo Apellido:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Primer Apellido:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(179, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Datos del Administrador";
            // 
            // tbUtilitarios
            // 
            this.tbUtilitarios.Controls.Add(this.groupBox6);
            this.tbUtilitarios.Location = new System.Drawing.Point(4, 29);
            this.tbUtilitarios.Name = "tbUtilitarios";
            this.tbUtilitarios.Size = new System.Drawing.Size(677, 499);
            this.tbUtilitarios.TabIndex = 2;
            this.tbUtilitarios.Text = "Utilitarios";
            this.tbUtilitarios.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.chkLuegoPrinter);
            this.groupBox6.Controls.Add(this.cbbImpresora);
            this.groupBox6.Controls.Add(this.btnFinalizar);
            this.groupBox6.Controls.Add(this.label20);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(677, 499);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Parametros de Configuración";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lblContrasenas);
            this.groupBox8.Controls.Add(this.txtContrasenaConfirmada);
            this.groupBox8.Controls.Add(this.label15);
            this.groupBox8.Controls.Add(this.txtContrasena);
            this.groupBox8.Controls.Add(this.label14);
            this.groupBox8.Controls.Add(this.lblValidMailDeliverer);
            this.groupBox8.Controls.Add(this.label11);
            this.groupBox8.Controls.Add(this.txtMailDeliverer);
            this.groupBox8.Controls.Add(this.txtPortNumber);
            this.groupBox8.Controls.Add(this.txtSmtp);
            this.groupBox8.Controls.Add(this.label19);
            this.groupBox8.Controls.Add(this.txtPuerto);
            this.groupBox8.Location = new System.Drawing.Point(38, 138);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(538, 292);
            this.groupBox8.TabIndex = 411;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Parametros de Correo";
            // 
            // lblContrasenas
            // 
            this.lblContrasenas.AutoSize = true;
            this.lblContrasenas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblContrasenas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblContrasenas.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenas.ForeColor = System.Drawing.Color.Red;
            this.lblContrasenas.Location = new System.Drawing.Point(253, 244);
            this.lblContrasenas.Name = "lblContrasenas";
            this.lblContrasenas.Size = new System.Drawing.Size(155, 17);
            this.lblContrasenas.TabIndex = 413;
            this.lblContrasenas.Text = "Contraseñas No Conciden";
            this.lblContrasenas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtContrasenaConfirmada
            // 
            this.txtContrasenaConfirmada.Location = new System.Drawing.Point(194, 209);
            this.txtContrasenaConfirmada.Name = "txtContrasenaConfirmada";
            this.txtContrasenaConfirmada.PasswordChar = '☻';
            this.txtContrasenaConfirmada.Size = new System.Drawing.Size(280, 26);
            this.txtContrasenaConfirmada.TabIndex = 412;
            this.txtContrasenaConfirmada.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtContrasenaConfirmada_KeyUp);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label15.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(29, 214);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(140, 15);
            this.label15.TabIndex = 411;
            this.label15.Text = "Confirmar Contraseña:";
            // 
            // txtContrasena
            // 
            this.txtContrasena.Location = new System.Drawing.Point(194, 174);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '☻';
            this.txtContrasena.Size = new System.Drawing.Size(280, 26);
            this.txtContrasena.TabIndex = 410;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label14.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(29, 179);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 15);
            this.label14.TabIndex = 409;
            this.label14.Text = "Contraseña:";
            // 
            // lblValidMailDeliverer
            // 
            this.lblValidMailDeliverer.AutoSize = true;
            this.lblValidMailDeliverer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValidMailDeliverer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblValidMailDeliverer.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValidMailDeliverer.ForeColor = System.Drawing.Color.Red;
            this.lblValidMailDeliverer.Location = new System.Drawing.Point(275, 145);
            this.lblValidMailDeliverer.Name = "lblValidMailDeliverer";
            this.lblValidMailDeliverer.Size = new System.Drawing.Size(101, 17);
            this.lblValidMailDeliverer.TabIndex = 408;
            this.lblValidMailDeliverer.Text = "Email No Válido";
            this.lblValidMailDeliverer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label11.Font = new System.Drawing.Font("Britannic Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(30, 113);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 15);
            this.label11.TabIndex = 406;
            this.label11.Text = "Email";
            // 
            // txtMailDeliverer
            // 
            this.txtMailDeliverer.Location = new System.Drawing.Point(193, 111);
            this.txtMailDeliverer.Name = "txtMailDeliverer";
            this.txtMailDeliverer.Size = new System.Drawing.Size(280, 26);
            this.txtMailDeliverer.TabIndex = 407;
            this.txtMailDeliverer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMailDeliverer_KeyPress);
            // 
            // txtPortNumber
            // 
            this.txtPortNumber.Location = new System.Drawing.Point(193, 68);
            this.txtPortNumber.Name = "txtPortNumber";
            this.txtPortNumber.Size = new System.Drawing.Size(112, 26);
            this.txtPortNumber.TabIndex = 7;
            // 
            // txtSmtp
            // 
            this.txtSmtp.Location = new System.Drawing.Point(193, 35);
            this.txtSmtp.Name = "txtSmtp";
            this.txtSmtp.Size = new System.Drawing.Size(280, 26);
            this.txtSmtp.TabIndex = 6;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(51, 20);
            this.label19.TabIndex = 4;
            this.label19.Text = "Smtp:";
            // 
            // txtPuerto
            // 
            this.txtPuerto.AutoSize = true;
            this.txtPuerto.Location = new System.Drawing.Point(29, 75);
            this.txtPuerto.Name = "txtPuerto";
            this.txtPuerto.Size = new System.Drawing.Size(60, 20);
            this.txtPuerto.TabIndex = 5;
            this.txtPuerto.Text = "Puerto:";
            // 
            // chkLuegoPrinter
            // 
            this.chkLuegoPrinter.AutoSize = true;
            this.chkLuegoPrinter.Location = new System.Drawing.Point(519, 91);
            this.chkLuegoPrinter.Name = "chkLuegoPrinter";
            this.chkLuegoPrinter.Size = new System.Drawing.Size(123, 24);
            this.chkLuegoPrinter.TabIndex = 410;
            this.chkLuegoPrinter.Text = "Definir Luego";
            this.chkLuegoPrinter.UseVisualStyleBackColor = true;
            this.chkLuegoPrinter.CheckedChanged += new System.EventHandler(this.chkLuegoPrinter_CheckedChanged);
            // 
            // cbbImpresora
            // 
            this.cbbImpresora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbImpresora.FormattingEnabled = true;
            this.cbbImpresora.Location = new System.Drawing.Point(232, 88);
            this.cbbImpresora.Name = "cbbImpresora";
            this.cbbImpresora.Size = new System.Drawing.Size(280, 28);
            this.cbbImpresora.TabIndex = 409;
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Location = new System.Drawing.Point(422, 436);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(220, 41);
            this.btnFinalizar.TabIndex = 406;
            this.btnFinalizar.Text = "Guardar Configuraciones";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(35, 88);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(166, 20);
            this.label20.TabIndex = 3;
            this.label20.Text = "Impresora de Ticketes";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnNext);
            this.groupBox3.Controls.Add(this.lblValidEmail);
            this.groupBox3.Controls.Add(this.txtTelefono);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtNombre);
            this.groupBox3.Controls.Add(this.txtApellido);
            this.groupBox3.Controls.Add(this.txtApellido2);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtDireccion);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtIdPersonal);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtEmail);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(671, 493);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Datos del Administrador";
            // 
            // btnConectar
            // 
            this.btnConectar.Location = new System.Drawing.Point(456, 392);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(112, 38);
            this.btnConectar.TabIndex = 22;
            this.btnConectar.Text = "Continuar";
            this.btnConectar.UseVisualStyleBackColor = true;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(699, 635);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración Inicial";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbMain, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.32686F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.67314F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(691, 606);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(685, 62);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Configuración de Parametros Iniciales";
            // 
            // tbMain
            // 
            this.tbMain.Controls.Add(this.tbConexión);
            this.tbMain.Controls.Add(this.tbDatos);
            this.tbMain.Controls.Add(this.tbUtilitarios);
            this.tbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMain.Location = new System.Drawing.Point(3, 71);
            this.tbMain.Name = "tbMain";
            this.tbMain.SelectedIndex = 0;
            this.tbMain.Size = new System.Drawing.Size(685, 532);
            this.tbMain.TabIndex = 1;
            // 
            // tbConexión
            // 
            this.tbConexión.Controls.Add(this.groupBox4);
            this.tbConexión.Location = new System.Drawing.Point(4, 29);
            this.tbConexión.Name = "tbConexión";
            this.tbConexión.Padding = new System.Windows.Forms.Padding(3);
            this.tbConexión.Size = new System.Drawing.Size(677, 499);
            this.tbConexión.TabIndex = 1;
            this.tbConexión.Text = "Conexión";
            this.tbConexión.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cancelButton);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.btnConectar);
            this.groupBox4.Controls.Add(this.groupBox7);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(671, 493);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Datos de Conexión";
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(326, 392);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 38);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Cancelar";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cmbInstancias);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Location = new System.Drawing.Point(16, 28);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(615, 87);
            this.groupBox5.TabIndex = 24;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "SQL Server";
            // 
            // cmbInstancias
            // 
            this.cmbInstancias.FormattingEnabled = true;
            this.cmbInstancias.Location = new System.Drawing.Point(199, 47);
            this.cmbInstancias.Name = "cmbInstancias";
            this.cmbInstancias.Size = new System.Drawing.Size(353, 28);
            this.cmbInstancias.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "Nombre de MSSQL Server:";
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.txtPassword);
            this.groupBox7.Controls.Add(this.label12);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.txtUsername);
            this.groupBox7.Controls.Add(this.rbSqlServer);
            this.groupBox7.Controls.Add(this.rbtWindosAut);
            this.groupBox7.Location = new System.Drawing.Point(3, 121);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(628, 148);
            this.groupBox7.TabIndex = 20;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Autenticación";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(192, 104);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(212, 26);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 107);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 20);
            this.label12.TabIndex = 12;
            this.label12.Text = "Contraseña:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(34, 75);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 20);
            this.label13.TabIndex = 11;
            this.label13.Text = "Nombre de Usuario:";
            // 
            // txtUsername
            // 
            this.txtUsername.Enabled = false;
            this.txtUsername.Location = new System.Drawing.Point(192, 75);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(212, 26);
            this.txtUsername.TabIndex = 10;
            // 
            // rbSqlServer
            // 
            this.rbSqlServer.AutoSize = true;
            this.rbSqlServer.Location = new System.Drawing.Point(9, 44);
            this.rbSqlServer.Name = "rbSqlServer";
            this.rbSqlServer.Size = new System.Drawing.Size(210, 24);
            this.rbSqlServer.TabIndex = 9;
            this.rbSqlServer.Text = "SQL Server Autenticación";
            this.rbSqlServer.UseVisualStyleBackColor = true;
            // 
            // rbtWindosAut
            // 
            this.rbtWindosAut.AutoSize = true;
            this.rbtWindosAut.Checked = true;
            this.rbtWindosAut.Location = new System.Drawing.Point(9, 21);
            this.rbtWindosAut.Name = "rbtWindosAut";
            this.rbtWindosAut.Size = new System.Drawing.Size(214, 24);
            this.rbtWindosAut.TabIndex = 8;
            this.rbtWindosAut.TabStop = true;
            this.rbtWindosAut.Text = "Autenticación de Windows";
            this.rbtWindosAut.UseVisualStyleBackColor = true;
            // 
            // tbDatos
            // 
            this.tbDatos.Controls.Add(this.groupBox3);
            this.tbDatos.Location = new System.Drawing.Point(4, 29);
            this.tbDatos.Name = "tbDatos";
            this.tbDatos.Padding = new System.Windows.Forms.Padding(3);
            this.tbDatos.Size = new System.Drawing.Size(677, 499);
            this.tbDatos.TabIndex = 0;
            this.tbDatos.Text = "Datos";
            this.tbDatos.UseVisualStyleBackColor = true;
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 635);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmConfiguracion";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.tbUtilitarios.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tbMain.ResumeLayout(false);
            this.tbConexión.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.tbDatos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblValidEmail;
        private System.Windows.Forms.MaskedTextBox txtTelefono;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtApellido2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIdPersonal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tbUtilitarios;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TabControl tbMain;
        private System.Windows.Forms.TabPage tbConexión;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cmbInstancias;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.RadioButton rbSqlServer;
        private System.Windows.Forms.RadioButton rbtWindosAut;
        private System.Windows.Forms.TabPage tbDatos;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox txtSmtp;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label txtPuerto;
        private System.Windows.Forms.CheckBox chkLuegoPrinter;
        private System.Windows.Forms.ComboBox cbbImpresora;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPortNumber;
        private System.Windows.Forms.Label lblContrasenas;
        private System.Windows.Forms.TextBox txtContrasenaConfirmada;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtContrasena;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblValidMailDeliverer;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtMailDeliverer;
    }
}