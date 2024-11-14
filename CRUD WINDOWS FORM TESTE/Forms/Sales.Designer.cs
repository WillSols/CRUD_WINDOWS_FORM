namespace CRUD_WINDOWS_FORM_TESTE.Forms
{
    partial class Sales
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
            components = new System.ComponentModel.Container();
            saleUpdateSave = new Button();
            saleDelete = new Button();
            saleUpdate = new Button();
            saleCreate = new Button();
            saleProductName = new TextBox();
            saleQty = new TextBox();
            saleName = new TextBox();
            productName = new Label();
            qty = new Label();
            Date = new Label();
            sName = new Label();
            dgSales = new DataGridView();
            saleList = new Button();
            saleDate = new DateTimePicker();
            toolTip1 = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)dgSales).BeginInit();
            SuspendLayout();
            // 
            // saleUpdateSave
            // 
            saleUpdateSave.Location = new Point(599, 197);
            saleUpdateSave.Name = "saleUpdateSave";
            saleUpdateSave.Size = new Size(161, 35);
            saleUpdateSave.TabIndex = 44;
            saleUpdateSave.Text = "Salvar Edição";
            saleUpdateSave.UseVisualStyleBackColor = true;
            saleUpdateSave.Click += saleUpdateSave_Click;
            // 
            // saleDelete
            // 
            saleDelete.Location = new Point(766, 197);
            saleDelete.Name = "saleDelete";
            saleDelete.Size = new Size(151, 35);
            saleDelete.TabIndex = 43;
            saleDelete.Text = "Deletar Venda";
            saleDelete.UseVisualStyleBackColor = true;
            saleDelete.Click += saleDelete_Click;
            // 
            // saleUpdate
            // 
            saleUpdate.Location = new Point(441, 197);
            saleUpdate.Name = "saleUpdate";
            saleUpdate.Size = new Size(152, 35);
            saleUpdate.TabIndex = 42;
            saleUpdate.Text = "Editar Venda";
            saleUpdate.UseVisualStyleBackColor = true;
            saleUpdate.Click += saleUpdate_Click;
            // 
            // saleCreate
            // 
            saleCreate.Location = new Point(923, 197);
            saleCreate.Name = "saleCreate";
            saleCreate.Size = new Size(145, 35);
            saleCreate.TabIndex = 41;
            saleCreate.Text = "Adicionar Venda";
            saleCreate.UseVisualStyleBackColor = true;
            saleCreate.Click += saleCreate_Click;
            // 
            // saleProductName
            // 
            saleProductName.Location = new Point(58, 122);
            saleProductName.Multiline = true;
            saleProductName.Name = "saleProductName";
            saleProductName.Size = new Size(297, 23);
            saleProductName.TabIndex = 39;
            toolTip1.SetToolTip(saleProductName, "Você pode adicionar mais de um produto nesse campo separando-o por uma vírgula.");
            // 
            // saleQty
            // 
            saleQty.Location = new Point(375, 122);
            saleQty.Name = "saleQty";
            saleQty.Size = new Size(117, 23);
            saleQty.TabIndex = 38;
            toolTip1.SetToolTip(saleQty, "Para cada produto adicionado no campo anterior, separe por vírgula e adicione a quantidade relativa neste campo.");
            // 
            // saleName
            // 
            saleName.Location = new Point(58, 55);
            saleName.Name = "saleName";
            saleName.Size = new Size(297, 23);
            saleName.TabIndex = 36;
            // 
            // productName
            // 
            productName.AutoSize = true;
            productName.Location = new Point(58, 99);
            productName.Name = "productName";
            productName.Size = new Size(103, 15);
            productName.TabIndex = 34;
            productName.Text = "Nome do Produto";
            // 
            // qty
            // 
            qty.AutoSize = true;
            qty.Location = new Point(375, 99);
            qty.Name = "qty";
            qty.Size = new Size(69, 15);
            qty.TabIndex = 33;
            qty.Text = "Quantidade";
            // 
            // Date
            // 
            Date.AutoSize = true;
            Date.Location = new Point(375, 32);
            Date.Name = "Date";
            Date.Size = new Size(82, 15);
            Date.TabIndex = 32;
            Date.Text = "Data da Venda";
            // 
            // sName
            // 
            sName.AutoSize = true;
            sName.Location = new Point(58, 32);
            sName.Name = "sName";
            sName.Size = new Size(97, 15);
            sName.TabIndex = 31;
            sName.Text = "Nome do Cliente";
            // 
            // dgSales
            // 
            dgSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSales.Location = new Point(58, 251);
            dgSales.Name = "dgSales";
            dgSales.Size = new Size(1010, 291);
            dgSales.TabIndex = 30;
            // 
            // saleList
            // 
            saleList.Location = new Point(58, 197);
            saleList.Name = "saleList";
            saleList.Size = new Size(152, 35);
            saleList.TabIndex = 45;
            saleList.Text = "Atualizar Lista";
            saleList.UseVisualStyleBackColor = true;
            saleList.Click += saleList_Click;
            // 
            // saleDate
            // 
            saleDate.Location = new Point(375, 55);
            saleDate.Name = "saleDate";
            saleDate.Size = new Size(200, 23);
            saleDate.TabIndex = 46;
            // 
            // Sales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1128, 568);
            Controls.Add(saleDate);
            Controls.Add(saleList);
            Controls.Add(saleUpdateSave);
            Controls.Add(saleDelete);
            Controls.Add(saleUpdate);
            Controls.Add(saleCreate);
            Controls.Add(saleProductName);
            Controls.Add(saleQty);
            Controls.Add(saleName);
            Controls.Add(productName);
            Controls.Add(qty);
            Controls.Add(Date);
            Controls.Add(sName);
            Controls.Add(dgSales);
            Name = "Sales";
            Text = "Sales";
            Load += Sales_Load;
            ((System.ComponentModel.ISupportInitialize)dgSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button saleUpdateSave;
        private Button saleDelete;
        private Button saleUpdate;
        private Button saleCreate;
        private TextBox saleProductName;
        private TextBox saleQty;
        private TextBox saleName;
        private Label productName;
        private Label qty;
        private Label Date;
        private Label sName;
        private DataGridView dgSales;
        private Button saleList;
        private DateTimePicker saleDate;
        private ToolTip toolTip1;
    }
}