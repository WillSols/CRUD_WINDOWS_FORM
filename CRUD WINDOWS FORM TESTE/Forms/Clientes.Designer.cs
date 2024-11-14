namespace CRUD_WINDOWS_FORM_TESTE.Forms
{
    partial class Clientes
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
            dgClients = new DataGridView();
            cName = new Label();
            Adress = new Label();
            DDD = new Label();
            Phone = new Label();
            Email = new Label();
            clientName = new TextBox();
            clientAddress = new TextBox();
            clientDDD = new TextBox();
            clientPhone = new TextBox();
            clientEmail = new TextBox();
            clientCreate = new Button();
            productUpdate = new Button();
            clientDelete = new Button();
            clientSearch = new Button();
            saveUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgClients).BeginInit();
            SuspendLayout();
            // 
            // dgClients
            // 
            dgClients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgClients.Location = new Point(12, 254);
            dgClients.Name = "dgClients";
            dgClients.Size = new Size(1010, 291);
            dgClients.TabIndex = 0;
            // 
            // cName
            // 
            cName.AutoSize = true;
            cName.Location = new Point(54, 36);
            cName.Name = "cName";
            cName.Size = new Size(40, 15);
            cName.TabIndex = 1;
            cName.Text = "Nome";
            // 
            // Adress
            // 
            Adress.AutoSize = true;
            Adress.Location = new Point(371, 36);
            Adress.Name = "Adress";
            Adress.Size = new Size(56, 15);
            Adress.TabIndex = 2;
            Adress.Text = "Endereço";
            // 
            // DDD
            // 
            DDD.AutoSize = true;
            DDD.Location = new Point(719, 36);
            DDD.Name = "DDD";
            DDD.Size = new Size(31, 15);
            DDD.TabIndex = 3;
            DDD.Text = "DDD";
            // 
            // Phone
            // 
            Phone.AutoSize = true;
            Phone.Location = new Point(756, 36);
            Phone.Name = "Phone";
            Phone.Size = new Size(51, 15);
            Phone.TabIndex = 4;
            Phone.Text = "Telefone";
            // 
            // Email
            // 
            Email.AutoSize = true;
            Email.Location = new Point(56, 99);
            Email.Name = "Email";
            Email.Size = new Size(41, 15);
            Email.TabIndex = 5;
            Email.Text = "E-mail";
            // 
            // clientName
            // 
            clientName.Location = new Point(54, 59);
            clientName.Name = "clientName";
            clientName.Size = new Size(297, 23);
            clientName.TabIndex = 6;
            // 
            // clientAddress
            // 
            clientAddress.Location = new Point(371, 59);
            clientAddress.Name = "clientAddress";
            clientAddress.Size = new Size(329, 23);
            clientAddress.TabIndex = 7;
            // 
            // clientDDD
            // 
            clientDDD.Location = new Point(719, 59);
            clientDDD.Name = "clientDDD";
            clientDDD.Size = new Size(31, 23);
            clientDDD.TabIndex = 8;
            // 
            // clientPhone
            // 
            clientPhone.Location = new Point(756, 59);
            clientPhone.Name = "clientPhone";
            clientPhone.Size = new Size(198, 23);
            clientPhone.TabIndex = 9;
            // 
            // clientEmail
            // 
            clientEmail.Location = new Point(56, 117);
            clientEmail.Name = "clientEmail";
            clientEmail.Size = new Size(295, 23);
            clientEmail.TabIndex = 10;
            // 
            // clientCreate
            // 
            clientCreate.Location = new Point(877, 200);
            clientCreate.Name = "clientCreate";
            clientCreate.Size = new Size(145, 35);
            clientCreate.TabIndex = 11;
            clientCreate.Text = "Adicionar Cliente";
            clientCreate.UseVisualStyleBackColor = true;
            clientCreate.Click += clientCreate_Click;
            // 
            // productUpdate
            // 
            productUpdate.Location = new Point(403, 200);
            productUpdate.Name = "productUpdate";
            productUpdate.Size = new Size(152, 35);
            productUpdate.TabIndex = 12;
            productUpdate.Text = "Editar Cliente";
            productUpdate.UseVisualStyleBackColor = true;
            productUpdate.Click += clientUpdate_Click;
            // 
            // clientDelete
            // 
            clientDelete.Location = new Point(719, 200);
            clientDelete.Name = "clientDelete";
            clientDelete.Size = new Size(151, 35);
            clientDelete.TabIndex = 13;
            clientDelete.Text = "Deletar Cliente";
            clientDelete.UseVisualStyleBackColor = true;
            clientDelete.Click += clientDelete_Click;
            // 
            // clientSearch
            // 
            clientSearch.Location = new Point(12, 200);
            clientSearch.Name = "clientSearch";
            clientSearch.Size = new Size(161, 35);
            clientSearch.TabIndex = 29;
            clientSearch.Text = "Atualizar Lista";
            clientSearch.UseVisualStyleBackColor = true;
            clientSearch.Click += clientSearch_Click;
            // 
            // saveUpdate
            // 
            saveUpdate.Location = new Point(561, 200);
            saveUpdate.Name = "saveUpdate";
            saveUpdate.Size = new Size(152, 35);
            saveUpdate.TabIndex = 30;
            saveUpdate.Text = "Salvar Edição";
            saveUpdate.UseVisualStyleBackColor = true;
            saveUpdate.Click += saveUpdate_Click;
            // 
            // Clientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 557);
            Controls.Add(saveUpdate);
            Controls.Add(clientSearch);
            Controls.Add(clientDelete);
            Controls.Add(productUpdate);
            Controls.Add(clientCreate);
            Controls.Add(clientEmail);
            Controls.Add(clientPhone);
            Controls.Add(clientDDD);
            Controls.Add(clientAddress);
            Controls.Add(clientName);
            Controls.Add(Email);
            Controls.Add(Phone);
            Controls.Add(DDD);
            Controls.Add(Adress);
            Controls.Add(cName);
            Controls.Add(dgClients);
            Name = "Clientes";
            Text = "Clients";
            Load += Clientes_Load;
            ((System.ComponentModel.ISupportInitialize)dgClients).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgClients;
        private Label cName;
        private Label Adress;
        private Label DDD;
        private Label Phone;
        private Label Email;
        private TextBox clientName;
        private TextBox clientAddress;
        private TextBox clientDDD;
        private TextBox clientPhone;
        private TextBox clientEmail;
        private Button clientCreate;
        private Button productUpdate;
        private Button clientDelete;
        private Button clientSearch;
        private Button saveUpdate;
    }
}