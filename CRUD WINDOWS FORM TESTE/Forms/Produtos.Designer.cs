namespace CRUD_WINDOWS_FORM_TESTE.Forms
{
    partial class Produtos
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
            productDelete = new Button();
            productUpdate = new Button();
            productCreate = new Button();
            productStock = new TextBox();
            productPrice = new TextBox();
            productDescription = new TextBox();
            productName = new TextBox();
            Stock = new Label();
            Price = new Label();
            Description = new Label();
            Product = new Label();
            dgProduct = new DataGridView();
            productSearch = new Button();
            productSaveUpdate = new Button();
            productSKU = new TextBox();
            SKU = new Label();
            ((System.ComponentModel.ISupportInitialize)dgProduct).BeginInit();
            SuspendLayout();
            // 
            // productDelete
            // 
            productDelete.Location = new Point(701, 220);
            productDelete.Name = "productDelete";
            productDelete.Size = new Size(161, 35);
            productDelete.TabIndex = 27;
            productDelete.Text = "Deletar Produto";
            productDelete.UseVisualStyleBackColor = true;
            productDelete.Click += productDelete_Click;
            // 
            // productUpdate
            // 
            productUpdate.Location = new Point(361, 220);
            productUpdate.Name = "productUpdate";
            productUpdate.Size = new Size(164, 35);
            productUpdate.TabIndex = 26;
            productUpdate.Text = "Editar Produto";
            productUpdate.UseVisualStyleBackColor = true;
            productUpdate.Click += productUpdate_Click;
            // 
            // productCreate
            // 
            productCreate.Location = new Point(868, 220);
            productCreate.Name = "productCreate";
            productCreate.Size = new Size(164, 35);
            productCreate.TabIndex = 25;
            productCreate.Text = "Adicionar Produto";
            productCreate.UseVisualStyleBackColor = true;
            productCreate.Click += productCreate_Click;
            // 
            // productStock
            // 
            productStock.Location = new Point(70, 125);
            productStock.Name = "productStock";
            productStock.Size = new Size(295, 23);
            productStock.TabIndex = 24;
            // 
            // productPrice
            // 
            productPrice.Location = new Point(733, 67);
            productPrice.Name = "productPrice";
            productPrice.Size = new Size(235, 23);
            productPrice.TabIndex = 22;
            // 
            // productDescription
            // 
            productDescription.Location = new Point(385, 67);
            productDescription.Name = "productDescription";
            productDescription.Size = new Size(329, 23);
            productDescription.TabIndex = 21;
            // 
            // productName
            // 
            productName.Location = new Point(68, 67);
            productName.Name = "productName";
            productName.Size = new Size(297, 23);
            productName.TabIndex = 20;
            // 
            // Stock
            // 
            Stock.AutoSize = true;
            Stock.Location = new Point(70, 107);
            Stock.Name = "Stock";
            Stock.Size = new Size(49, 15);
            Stock.TabIndex = 19;
            Stock.Text = "Estoque";
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Location = new Point(733, 44);
            Price.Name = "Price";
            Price.Size = new Size(37, 15);
            Price.TabIndex = 17;
            Price.Text = "Preço";
            // 
            // Description
            // 
            Description.AutoSize = true;
            Description.Location = new Point(385, 44);
            Description.Name = "Description";
            Description.Size = new Size(58, 15);
            Description.TabIndex = 16;
            Description.Text = "Descrição";
            // 
            // Product
            // 
            Product.AutoSize = true;
            Product.Location = new Point(68, 44);
            Product.Name = "Product";
            Product.Size = new Size(103, 15);
            Product.TabIndex = 15;
            Product.Text = "Nome do Produto";
            // 
            // dgProduct
            // 
            dgProduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgProduct.Location = new Point(22, 270);
            dgProduct.Name = "dgProduct";
            dgProduct.Size = new Size(1010, 291);
            dgProduct.TabIndex = 14;
            // 
            // productSearch
            // 
            productSearch.Location = new Point(22, 220);
            productSearch.Name = "productSearch";
            productSearch.Size = new Size(161, 35);
            productSearch.TabIndex = 28;
            productSearch.Text = "Atualizar Lista";
            productSearch.UseVisualStyleBackColor = true;
            productSearch.Click += productSearch_Click;
            // 
            // productSaveUpdate
            // 
            productSaveUpdate.Location = new Point(531, 220);
            productSaveUpdate.Name = "productSaveUpdate";
            productSaveUpdate.Size = new Size(164, 35);
            productSaveUpdate.TabIndex = 29;
            productSaveUpdate.Text = "Salvar Edição";
            productSaveUpdate.UseVisualStyleBackColor = true;
            productSaveUpdate.Click += productSaveUpdate_Click;
            // 
            // productSKU
            // 
            productSKU.Location = new Point(385, 125);
            productSKU.Name = "productSKU";
            productSKU.Size = new Size(295, 23);
            productSKU.TabIndex = 30;
            // 
            // SKU
            // 
            SKU.AutoSize = true;
            SKU.Location = new Point(385, 107);
            SKU.Name = "SKU";
            SKU.Size = new Size(28, 15);
            SKU.TabIndex = 31;
            SKU.Text = "SKU";
            // 
            // Produtos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1061, 585);
            Controls.Add(SKU);
            Controls.Add(productSKU);
            Controls.Add(productSaveUpdate);
            Controls.Add(productSearch);
            Controls.Add(productDelete);
            Controls.Add(productUpdate);
            Controls.Add(productCreate);
            Controls.Add(productStock);
            Controls.Add(productPrice);
            Controls.Add(productDescription);
            Controls.Add(productName);
            Controls.Add(Stock);
            Controls.Add(Price);
            Controls.Add(Description);
            Controls.Add(Product);
            Controls.Add(dgProduct);
            Name = "Produtos";
            Text = "Products";
            Load += Produtos_Load;
            ((System.ComponentModel.ISupportInitialize)dgProduct).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button productDelete;
        private Button productUpdate;
        private Button productCreate;
        private TextBox productStock;
        private TextBox productPrice;
        private TextBox productDescription;
        private TextBox productName;
        private Label Stock;
        private Label Price;
        private Label Description;
        private Label Product;
        private DataGridView dgProduct;
        private Button productSearch;
        private Button productSaveUpdate;
        private TextBox productSKU;
        private Label SKU;
    }
}