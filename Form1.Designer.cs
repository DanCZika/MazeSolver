namespace labirintusHázi
{
    partial class Form1
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.utasításokToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importálásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.megoldásSzélességiKeresésselToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.megoldásRekurzívmélységiKeresésselToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.megoldásVéletlenKeresésselToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.megoldásThémauxKeresésévelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kirajzolásToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alapLabirintusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.themauxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szélességiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rekurzívmélységiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lassításToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nincsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lassúToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.láthatóToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gyorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eszméletlenGyorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jelképesenLassítvaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lassítatlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.keresésMegállításaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lépésszámToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.térképMentéseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utasításokToolStripMenuItem,
            this.kirajzolásToolStripMenuItem,
            this.lassításToolStripMenuItem,
            this.lépésszámToolStripMenuItem,
            this.toolStripMenuItem1,
            this.keresésMegállításaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(551, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // utasításokToolStripMenuItem
            // 
            this.utasításokToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importálásToolStripMenuItem,
            this.megoldásSzélességiKeresésselToolStripMenuItem,
            this.megoldásRekurzívmélységiKeresésselToolStripMenuItem,
            this.megoldásVéletlenKeresésselToolStripMenuItem,
            this.megoldásThémauxKeresésévelToolStripMenuItem});
            this.utasításokToolStripMenuItem.Name = "utasításokToolStripMenuItem";
            this.utasításokToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.utasításokToolStripMenuItem.Text = "Utasítások";
            // 
            // importálásToolStripMenuItem
            // 
            this.importálásToolStripMenuItem.Name = "importálásToolStripMenuItem";
            this.importálásToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.importálásToolStripMenuItem.Text = "Importálás";
            this.importálásToolStripMenuItem.Click += new System.EventHandler(this.importálásToolStripMenuItem_Click);
            // 
            // megoldásSzélességiKeresésselToolStripMenuItem
            // 
            this.megoldásSzélességiKeresésselToolStripMenuItem.Name = "megoldásSzélességiKeresésselToolStripMenuItem";
            this.megoldásSzélességiKeresésselToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.megoldásSzélességiKeresésselToolStripMenuItem.Text = "Megoldás szélességi kereséssel";
            this.megoldásSzélességiKeresésselToolStripMenuItem.Click += new System.EventHandler(this.megoldásSzélességiKeresésselToolStripMenuItem_Click);
            // 
            // megoldásRekurzívmélységiKeresésselToolStripMenuItem
            // 
            this.megoldásRekurzívmélységiKeresésselToolStripMenuItem.Name = "megoldásRekurzívmélységiKeresésselToolStripMenuItem";
            this.megoldásRekurzívmélységiKeresésselToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.megoldásRekurzívmélységiKeresésselToolStripMenuItem.Text = "Megoldás rekurzív (mélységi) kereséssel";
            this.megoldásRekurzívmélységiKeresésselToolStripMenuItem.Click += new System.EventHandler(this.megoldásRekurzívmélységiKeresésselToolStripMenuItem_Click);
            // 
            // megoldásVéletlenKeresésselToolStripMenuItem
            // 
            this.megoldásVéletlenKeresésselToolStripMenuItem.Name = "megoldásVéletlenKeresésselToolStripMenuItem";
            this.megoldásVéletlenKeresésselToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.megoldásVéletlenKeresésselToolStripMenuItem.Text = "Megoldás véletlen kereséssel";
            this.megoldásVéletlenKeresésselToolStripMenuItem.Click += new System.EventHandler(this.megoldásVéletlenKeresésselToolStripMenuItem_Click);
            // 
            // megoldásThémauxKeresésévelToolStripMenuItem
            // 
            this.megoldásThémauxKeresésévelToolStripMenuItem.Name = "megoldásThémauxKeresésévelToolStripMenuItem";
            this.megoldásThémauxKeresésévelToolStripMenuItem.Size = new System.Drawing.Size(283, 22);
            this.megoldásThémauxKeresésévelToolStripMenuItem.Text = "Megoldás Thémaux keresésével";
            this.megoldásThémauxKeresésévelToolStripMenuItem.Click += new System.EventHandler(this.megoldásThémauxKeresésévelToolStripMenuItem_Click);
            // 
            // kirajzolásToolStripMenuItem
            // 
            this.kirajzolásToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alapLabirintusToolStripMenuItem,
            this.randomToolStripMenuItem,
            this.themauxToolStripMenuItem,
            this.szélességiToolStripMenuItem,
            this.rekurzívmélységiToolStripMenuItem});
            this.kirajzolásToolStripMenuItem.Name = "kirajzolásToolStripMenuItem";
            this.kirajzolásToolStripMenuItem.Size = new System.Drawing.Size(68, 20);
            this.kirajzolásToolStripMenuItem.Text = "Kirajzolás";
            // 
            // alapLabirintusToolStripMenuItem
            // 
            this.alapLabirintusToolStripMenuItem.Name = "alapLabirintusToolStripMenuItem";
            this.alapLabirintusToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.alapLabirintusToolStripMenuItem.Text = "Alap labirintus";
            this.alapLabirintusToolStripMenuItem.Click += new System.EventHandler(this.alapLabirintusToolStripMenuItem_Click);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.randomToolStripMenuItem.Text = "Random";
            this.randomToolStripMenuItem.Click += new System.EventHandler(this.randomToolStripMenuItem_Click);
            // 
            // themauxToolStripMenuItem
            // 
            this.themauxToolStripMenuItem.Name = "themauxToolStripMenuItem";
            this.themauxToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.themauxToolStripMenuItem.Text = "Themaux";
            this.themauxToolStripMenuItem.Click += new System.EventHandler(this.themauxToolStripMenuItem_Click);
            // 
            // szélességiToolStripMenuItem
            // 
            this.szélességiToolStripMenuItem.Name = "szélességiToolStripMenuItem";
            this.szélességiToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.szélességiToolStripMenuItem.Text = "Szélességi";
            this.szélességiToolStripMenuItem.Click += new System.EventHandler(this.szélességiToolStripMenuItem_Click);
            // 
            // rekurzívmélységiToolStripMenuItem
            // 
            this.rekurzívmélységiToolStripMenuItem.Name = "rekurzívmélységiToolStripMenuItem";
            this.rekurzívmélységiToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.rekurzívmélységiToolStripMenuItem.Text = "Rekurzív (mélységi)";
            this.rekurzívmélységiToolStripMenuItem.Click += new System.EventHandler(this.rekurzívmélységiToolStripMenuItem_Click);
            // 
            // lassításToolStripMenuItem
            // 
            this.lassításToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nincsToolStripMenuItem,
            this.lassúToolStripMenuItem,
            this.láthatóToolStripMenuItem,
            this.gyorsToolStripMenuItem,
            this.eszméletlenGyorsToolStripMenuItem,
            this.jelképesenLassítvaToolStripMenuItem,
            this.lassítatlanToolStripMenuItem});
            this.lassításToolStripMenuItem.Name = "lassításToolStripMenuItem";
            this.lassításToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.lassításToolStripMenuItem.Text = "Lassítás";
            // 
            // nincsToolStripMenuItem
            // 
            this.nincsToolStripMenuItem.Name = "nincsToolStripMenuItem";
            this.nincsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.nincsToolStripMenuItem.Text = "Nincs valós idejú kijelzés";
            this.nincsToolStripMenuItem.Click += new System.EventHandler(this.nincsToolStripMenuItem_Click);
            // 
            // lassúToolStripMenuItem
            // 
            this.lassúToolStripMenuItem.Name = "lassúToolStripMenuItem";
            this.lassúToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.lassúToolStripMenuItem.Text = "Lassú";
            this.lassúToolStripMenuItem.Click += new System.EventHandler(this.lassúToolStripMenuItem_Click);
            // 
            // láthatóToolStripMenuItem
            // 
            this.láthatóToolStripMenuItem.Name = "láthatóToolStripMenuItem";
            this.láthatóToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.láthatóToolStripMenuItem.Text = "Közepes";
            this.láthatóToolStripMenuItem.Click += new System.EventHandler(this.láthatóToolStripMenuItem_Click);
            // 
            // gyorsToolStripMenuItem
            // 
            this.gyorsToolStripMenuItem.Name = "gyorsToolStripMenuItem";
            this.gyorsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.gyorsToolStripMenuItem.Text = "Gyors";
            this.gyorsToolStripMenuItem.Click += new System.EventHandler(this.gyorsToolStripMenuItem_Click);
            // 
            // eszméletlenGyorsToolStripMenuItem
            // 
            this.eszméletlenGyorsToolStripMenuItem.Name = "eszméletlenGyorsToolStripMenuItem";
            this.eszméletlenGyorsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.eszméletlenGyorsToolStripMenuItem.Text = "Hipergyors";
            this.eszméletlenGyorsToolStripMenuItem.Click += new System.EventHandler(this.eszméletlenGyorsToolStripMenuItem_Click);
            // 
            // jelképesenLassítvaToolStripMenuItem
            // 
            this.jelképesenLassítvaToolStripMenuItem.Name = "jelképesenLassítvaToolStripMenuItem";
            this.jelképesenLassítvaToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.jelképesenLassítvaToolStripMenuItem.Text = "Jelképesen lassítva";
            this.jelképesenLassítvaToolStripMenuItem.Click += new System.EventHandler(this.jelképesenLassítvaToolStripMenuItem_Click);
            // 
            // lassítatlanToolStripMenuItem
            // 
            this.lassítatlanToolStripMenuItem.Name = "lassítatlanToolStripMenuItem";
            this.lassítatlanToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.lassítatlanToolStripMenuItem.Text = "Lassítatlan";
            this.lassítatlanToolStripMenuItem.Click += new System.EventHandler(this.lassítatlanToolStripMenuItem_Click);
            // 
            // keresésMegállításaToolStripMenuItem
            // 
            this.keresésMegállításaToolStripMenuItem.Name = "keresésMegállításaToolStripMenuItem";
            this.keresésMegállításaToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.keresésMegállításaToolStripMenuItem.Text = "Keresés megállítása";
            this.keresésMegállításaToolStripMenuItem.Click += new System.EventHandler(this.keresésMegállításaToolStripMenuItem_Click);
            // 
            // lépésszámToolStripMenuItem
            // 
            this.lépésszámToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.térképMentéseToolStripMenuItem});
            this.lépésszámToolStripMenuItem.Name = "lépésszámToolStripMenuItem";
            this.lépésszámToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.lépésszámToolStripMenuItem.Text = "Lépésszám";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 263);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // térképMentéseToolStripMenuItem
            // 
            this.térképMentéseToolStripMenuItem.Name = "térképMentéseToolStripMenuItem";
            this.térképMentéseToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.térképMentéseToolStripMenuItem.Text = "Térkép mentése";
            this.térképMentéseToolStripMenuItem.Click += new System.EventHandler(this.térképMentéseToolStripMenuItem_Click);
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(85, 20);
            this.toolStripMenuItem1.Text = "......................";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 518);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem utasításokToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importálásToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem megoldásSzélességiKeresésselToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem megoldásRekurzívmélységiKeresésselToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem megoldásVéletlenKeresésselToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem megoldásThémauxKeresésévelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kirajzolásToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alapLabirintusToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem themauxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szélességiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rekurzívmélységiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lassításToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nincsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lassúToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem láthatóToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gyorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eszméletlenGyorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jelképesenLassítvaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem keresésMegállításaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lassítatlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lépésszámToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem térképMentéseToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

