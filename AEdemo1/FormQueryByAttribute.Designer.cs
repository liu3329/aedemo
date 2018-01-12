namespace AEdemo1
{
    partial class FormQueryByAttribute
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
            this.comboBoxLayerName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonApply = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.textBoxWhere = new System.Windows.Forms.TextBox();
            this.labelwhere = new System.Windows.Forms.Label();
            this.labelSelect = new System.Windows.Forms.Label();
            this.buttonGetUniqeValue = new System.Windows.Forms.Button();
            this.listBoxValues = new System.Windows.Forms.ListBox();
            this.buttonPercent = new System.Windows.Forms.Button();
            this.buttonUnderLine = new System.Windows.Forms.Button();
            this.buttonIs = new System.Windows.Forms.Button();
            this.buttonNot = new System.Windows.Forms.Button();
            this.buttonBrackets = new System.Windows.Forms.Button();
            this.buttonOr = new System.Windows.Forms.Button();
            this.buttonLessEqual = new System.Windows.Forms.Button();
            this.buttonLess = new System.Windows.Forms.Button();
            this.buttonAnd = new System.Windows.Forms.Button();
            this.buttonGeaterEqual = new System.Windows.Forms.Button();
            this.buttonGreater = new System.Windows.Forms.Button();
            this.buttonLike = new System.Windows.Forms.Button();
            this.buttonNotEqual = new System.Windows.Forms.Button();
            this.buttonEqual = new System.Windows.Forms.Button();
            this.listBoxFields = new System.Windows.Forms.ListBox();
            this.comboBoxSelectMethod = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图层名称：";
            // 
            // comboBoxLayerName
            // 
            this.comboBoxLayerName.FormattingEnabled = true;
            this.comboBoxLayerName.Location = new System.Drawing.Point(74, 5);
            this.comboBoxLayerName.Name = "comboBoxLayerName";
            this.comboBoxLayerName.Size = new System.Drawing.Size(364, 20);
            this.comboBoxLayerName.TabIndex = 1;
            this.comboBoxLayerName.SelectedIndexChanged += new System.EventHandler(this.comboBoxLayerName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "选择方式:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(74, 32);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "只显示可选图层";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(383, 444);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(56, 20);
            this.buttonClose.TabIndex = 59;
            this.buttonClose.Text = "关闭";
            this.buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.Location = new System.Drawing.Point(307, 444);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Size = new System.Drawing.Size(56, 20);
            this.buttonApply.TabIndex = 58;
            this.buttonApply.Text = "应用";
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(227, 444);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(56, 20);
            this.buttonOK.TabIndex = 57;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 429);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 3);
            this.groupBox1.TabIndex = 56;
            this.groupBox1.TabStop = false;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(29, 398);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(56, 20);
            this.buttonClear.TabIndex = 55;
            this.buttonClear.Text = "清除";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // textBoxWhere
            // 
            this.textBoxWhere.Location = new System.Drawing.Point(12, 303);
            this.textBoxWhere.Multiline = true;
            this.textBoxWhere.Name = "textBoxWhere";
            this.textBoxWhere.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.textBoxWhere.Size = new System.Drawing.Size(436, 89);
            this.textBoxWhere.TabIndex = 54;
            // 
            // labelwhere
            // 
            this.labelwhere.AutoSize = true;
            this.labelwhere.Location = new System.Drawing.Point(98, 278);
            this.labelwhere.Name = "labelwhere";
            this.labelwhere.Size = new System.Drawing.Size(11, 12);
            this.labelwhere.TabIndex = 53;
            this.labelwhere.Text = " ";
            // 
            // labelSelect
            // 
            this.labelSelect.AutoSize = true;
            this.labelSelect.Location = new System.Drawing.Point(10, 278);
            this.labelSelect.Name = "labelSelect";
            this.labelSelect.Size = new System.Drawing.Size(89, 12);
            this.labelSelect.TabIndex = 52;
            this.labelSelect.Text = "SELECT * FORM ";
            // 
            // buttonGetUniqeValue
            // 
            this.buttonGetUniqeValue.Location = new System.Drawing.Point(319, 254);
            this.buttonGetUniqeValue.Name = "buttonGetUniqeValue";
            this.buttonGetUniqeValue.Size = new System.Drawing.Size(120, 20);
            this.buttonGetUniqeValue.TabIndex = 51;
            this.buttonGetUniqeValue.Text = "获取唯一属性值";
            this.buttonGetUniqeValue.UseVisualStyleBackColor = true;
            this.buttonGetUniqeValue.Click += new System.EventHandler(this.buttonGetUniqeValue_Click);
            // 
            // listBoxValues
            // 
            this.listBoxValues.FormattingEnabled = true;
            this.listBoxValues.ItemHeight = 12;
            this.listBoxValues.Location = new System.Drawing.Point(317, 100);
            this.listBoxValues.Name = "listBoxValues";
            this.listBoxValues.Size = new System.Drawing.Size(131, 148);
            this.listBoxValues.TabIndex = 50;
            // 
            // buttonPercent
            // 
            this.buttonPercent.Location = new System.Drawing.Point(182, 193);
            this.buttonPercent.Name = "buttonPercent";
            this.buttonPercent.Size = new System.Drawing.Size(20, 31);
            this.buttonPercent.TabIndex = 49;
            this.buttonPercent.Text = "%";
            this.buttonPercent.UseVisualStyleBackColor = true;
            // 
            // buttonUnderLine
            // 
            this.buttonUnderLine.Location = new System.Drawing.Point(160, 193);
            this.buttonUnderLine.Name = "buttonUnderLine";
            this.buttonUnderLine.Size = new System.Drawing.Size(20, 31);
            this.buttonUnderLine.TabIndex = 48;
            this.buttonUnderLine.Text = "_";
            this.buttonUnderLine.UseVisualStyleBackColor = true;
            // 
            // buttonIs
            // 
            this.buttonIs.Location = new System.Drawing.Point(160, 230);
            this.buttonIs.Name = "buttonIs";
            this.buttonIs.Size = new System.Drawing.Size(42, 18);
            this.buttonIs.TabIndex = 47;
            this.buttonIs.Text = "Is";
            this.buttonIs.UseVisualStyleBackColor = true;
            // 
            // buttonNot
            // 
            this.buttonNot.Location = new System.Drawing.Point(256, 193);
            this.buttonNot.Name = "buttonNot";
            this.buttonNot.Size = new System.Drawing.Size(42, 31);
            this.buttonNot.TabIndex = 46;
            this.buttonNot.Text = "Not";
            this.buttonNot.UseVisualStyleBackColor = true;
            // 
            // buttonBrackets
            // 
            this.buttonBrackets.Location = new System.Drawing.Point(208, 193);
            this.buttonBrackets.Name = "buttonBrackets";
            this.buttonBrackets.Size = new System.Drawing.Size(42, 31);
            this.buttonBrackets.TabIndex = 45;
            this.buttonBrackets.Text = "( )";
            this.buttonBrackets.UseVisualStyleBackColor = true;
            // 
            // buttonOr
            // 
            this.buttonOr.Location = new System.Drawing.Point(256, 162);
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(42, 18);
            this.buttonOr.TabIndex = 44;
            this.buttonOr.Text = "Or";
            this.buttonOr.UseVisualStyleBackColor = true;
            // 
            // buttonLessEqual
            // 
            this.buttonLessEqual.Location = new System.Drawing.Point(208, 162);
            this.buttonLessEqual.Name = "buttonLessEqual";
            this.buttonLessEqual.Size = new System.Drawing.Size(42, 18);
            this.buttonLessEqual.TabIndex = 43;
            this.buttonLessEqual.Text = "<=";
            this.buttonLessEqual.UseVisualStyleBackColor = true;
            // 
            // buttonLess
            // 
            this.buttonLess.Location = new System.Drawing.Point(160, 162);
            this.buttonLess.Name = "buttonLess";
            this.buttonLess.Size = new System.Drawing.Size(42, 18);
            this.buttonLess.TabIndex = 42;
            this.buttonLess.Text = "<";
            this.buttonLess.UseVisualStyleBackColor = true;
            // 
            // buttonAnd
            // 
            this.buttonAnd.Location = new System.Drawing.Point(256, 131);
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(42, 18);
            this.buttonAnd.TabIndex = 41;
            this.buttonAnd.Text = "And";
            this.buttonAnd.UseVisualStyleBackColor = true;
            // 
            // buttonGeaterEqual
            // 
            this.buttonGeaterEqual.Location = new System.Drawing.Point(208, 131);
            this.buttonGeaterEqual.Name = "buttonGeaterEqual";
            this.buttonGeaterEqual.Size = new System.Drawing.Size(42, 18);
            this.buttonGeaterEqual.TabIndex = 40;
            this.buttonGeaterEqual.Text = ">=";
            this.buttonGeaterEqual.UseVisualStyleBackColor = true;
            // 
            // buttonGreater
            // 
            this.buttonGreater.Location = new System.Drawing.Point(160, 131);
            this.buttonGreater.Name = "buttonGreater";
            this.buttonGreater.Size = new System.Drawing.Size(42, 18);
            this.buttonGreater.TabIndex = 39;
            this.buttonGreater.Text = ">";
            this.buttonGreater.UseVisualStyleBackColor = true;
            // 
            // buttonLike
            // 
            this.buttonLike.Location = new System.Drawing.Point(256, 100);
            this.buttonLike.Name = "buttonLike";
            this.buttonLike.Size = new System.Drawing.Size(42, 18);
            this.buttonLike.TabIndex = 38;
            this.buttonLike.Text = "Like";
            this.buttonLike.UseVisualStyleBackColor = true;
            // 
            // buttonNotEqual
            // 
            this.buttonNotEqual.Location = new System.Drawing.Point(208, 100);
            this.buttonNotEqual.Name = "buttonNotEqual";
            this.buttonNotEqual.Size = new System.Drawing.Size(42, 18);
            this.buttonNotEqual.TabIndex = 37;
            this.buttonNotEqual.Text = "<>";
            this.buttonNotEqual.UseVisualStyleBackColor = true;
            // 
            // buttonEqual
            // 
            this.buttonEqual.Location = new System.Drawing.Point(160, 100);
            this.buttonEqual.Name = "buttonEqual";
            this.buttonEqual.Size = new System.Drawing.Size(42, 18);
            this.buttonEqual.TabIndex = 36;
            this.buttonEqual.Text = "=";
            this.buttonEqual.UseVisualStyleBackColor = true;
            // 
            // listBoxFields
            // 
            this.listBoxFields.FormattingEnabled = true;
            this.listBoxFields.ItemHeight = 12;
            this.listBoxFields.Location = new System.Drawing.Point(12, 100);
            this.listBoxFields.Name = "listBoxFields";
            this.listBoxFields.Size = new System.Drawing.Size(131, 148);
            this.listBoxFields.TabIndex = 35;
            this.listBoxFields.SelectedIndexChanged += new System.EventHandler(this.listBoxFields_SelectedIndexChanged);
            // 
            // comboBoxSelectMethod
            // 
            this.comboBoxSelectMethod.FormattingEnabled = true;
            this.comboBoxSelectMethod.Items.AddRange(new object[] {
            "创建新选择集",
            "添加到当前选择集",
            "从当前选择集中删除",
            "从当前选择集中选择"});
            this.comboBoxSelectMethod.Location = new System.Drawing.Point(74, 63);
            this.comboBoxSelectMethod.Name = "comboBoxSelectMethod";
            this.comboBoxSelectMethod.Size = new System.Drawing.Size(367, 20);
            this.comboBoxSelectMethod.TabIndex = 60;
            // 
            // FormQueryByAttribute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 531);
            this.Controls.Add(this.comboBoxSelectMethod);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.textBoxWhere);
            this.Controls.Add(this.labelwhere);
            this.Controls.Add(this.labelSelect);
            this.Controls.Add(this.buttonGetUniqeValue);
            this.Controls.Add(this.listBoxValues);
            this.Controls.Add(this.buttonPercent);
            this.Controls.Add(this.buttonUnderLine);
            this.Controls.Add(this.buttonIs);
            this.Controls.Add(this.buttonNot);
            this.Controls.Add(this.buttonBrackets);
            this.Controls.Add(this.buttonOr);
            this.Controls.Add(this.buttonLessEqual);
            this.Controls.Add(this.buttonLess);
            this.Controls.Add(this.buttonAnd);
            this.Controls.Add(this.buttonGeaterEqual);
            this.Controls.Add(this.buttonGreater);
            this.Controls.Add(this.buttonLike);
            this.Controls.Add(this.buttonNotEqual);
            this.Controls.Add(this.buttonEqual);
            this.Controls.Add(this.listBoxFields);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxLayerName);
            this.Controls.Add(this.label1);
            this.Name = "FormQueryByAttribute";
            this.Text = "FormQueryByAttribute";
            this.Load += new System.EventHandler(this.FormQueryByAttribute_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxLayerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonApply;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.TextBox textBoxWhere;
        private System.Windows.Forms.Label labelwhere;
        private System.Windows.Forms.Label labelSelect;
        private System.Windows.Forms.Button buttonGetUniqeValue;
        private System.Windows.Forms.ListBox listBoxValues;
        private System.Windows.Forms.Button buttonPercent;
        private System.Windows.Forms.Button buttonUnderLine;
        private System.Windows.Forms.Button buttonIs;
        private System.Windows.Forms.Button buttonNot;
        private System.Windows.Forms.Button buttonBrackets;
        private System.Windows.Forms.Button buttonOr;
        private System.Windows.Forms.Button buttonLessEqual;
        private System.Windows.Forms.Button buttonLess;
        private System.Windows.Forms.Button buttonAnd;
        private System.Windows.Forms.Button buttonGeaterEqual;
        private System.Windows.Forms.Button buttonGreater;
        private System.Windows.Forms.Button buttonLike;
        private System.Windows.Forms.Button buttonNotEqual;
        private System.Windows.Forms.Button buttonEqual;
        private System.Windows.Forms.ListBox listBoxFields;
        private System.Windows.Forms.ComboBox comboBoxSelectMethod;
    }
}