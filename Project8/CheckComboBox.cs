using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;


namespace MyComboBoxRadioButton
{
    /// <summary>
    /// <seealso cref="ComboBox"/> sınıfı <seealso cref="MyRadioButton"/> ve <seealso cref="System.Windows.Forms.ComboBox"/>
    /// sınıflarının bir araya getirilmesinden oluşmaktadır.
    /// </summary>
    [Designer(typeof(ComboBoxDesigner))]
    public partial class ComboBox : Control
    {
        /// <summary>
        /// <c>ComboBoxDropDown</c> değişkeni, <seealso cref="System.Windows.Forms.ComboBox"/> kontrolüne tıkladığımızda 
        /// görüntülenecek listeyi temsil eder. 
        /// </summary>
        private readonly ComboBoxDropDown comboBoxDropDown;

        /// <summary>
        /// <c>comboBox</c> değişkeni, <seealso cref="MyRadioButton"/> kontrollerini içerecek olan 
        /// <seealso cref="System.Windows.Forms.ComboBox"/> kontrolünü tanımlar.
        /// </summary>
        private readonly System.Windows.Forms.ComboBox comboBox;

        /// <summary>
        /// <c>items</c> değişkeni, <seealso cref="System.Windows.Forms.ComboBox"/> kontrolüne eklediğimiz 
        /// <seealso cref="RadioButton"/> kontrollerini içerir.
        /// </summary>
        private readonly ComboBoxCollection items;

        /// <summary>
        /// <seealso cref="ComboBox"/> sınıfı <seealso cref="RadioButton"/>  ve <seealso cref="System.Windows.Forms.ComboBox"/> 
        /// sınıflarının bir araya getirilmesinden oluşmaktadır.
        /// </summary>
        public ComboBox() : base()
        {
            comboBox = new System.Windows.Forms.ComboBox();
            comboBox.MouseDown += ComboBox_MouseDown;
            comboBox.DropDownHeight = 1;
            Controls.Add(comboBox);

            comboBoxDropDown = new ComboBoxDropDown(comboBox);
            comboBoxDropDown.MinimumSize = new Size(comboBox.Width, comboBoxDropDown.Height);
            comboBoxDropDown.BackColor = comboBox.BackColor;

            items = new ComboBoxCollection(comboBoxDropDown);
        }

        /// <summary>
        /// <seealso cref="ComboBox"/> kontrolü içerisindeki <seealso cref="RadioButton"/> kontrollerinin 
        /// herbirine erişmek için kullanılır. Bunun için <paramref name="index"/> parametresi kullanılır.
        /// </summary>
        /// <param name="index">Erişmek istenilen kontrolün indeksini ifade eder.</param>
        /// <returns>Geriye bir <seealso cref="RadioButton"/> tipinde nesne döndürülür.</returns>
        public MyRadioButton this[int index]
        {
            get => items[index];
            set => items[index] = value;
        }
        
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified) => base.SetBoundsCore(x, y, width, 28, specified);

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            comboBox.Size = Size;
        }

        private void ComboBox_MouseDown(object sender, MouseEventArgs e)
        {
            // ComboBox kontrolüne tıklanıldığında açılacak listenin konum ve ebatını belirle
            comboBoxDropDown.Show(comboBox, comboBox.Location.X, comboBox.Location.Y + comboBox.Height);
        }

        /// <summary>
        /// <c>Items</c> özelliği, <seealso cref="ComboBox"/> kontrolü içerisindeki 
        /// <seealso cref="RadioButton"/> kontrollerini temsil eder.
        /// </summary>
        /// <value><c>Items</c> özelliği, <seealso cref="ComboBoxCollection"/> koleksiyonun içeriğine erişir 
        /// veya yazar, <see cref="items"/></value>
        [Category("Data")]
        [Description("ComboBox içerisindeki elemanlar")]
        [Editor(typeof(ComboBoxCollectionEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ComboBoxCollection Items => items;

        /// <summary>
        /// Diğer kontrollere veya özelleştirilmiş kontrollere ev sahipliği yapan bir sınıftır. 
        /// <seealso cref="ToolStripControlHost"/> sınıfından türetilmiştir.
        /// </summary>
        internal class ToolStripRadioButton : ToolStripControlHost
        {
            private readonly ComboBoxDropDown comboBoxDropDown;

            public ToolStripRadioButton(MyRadioButton myRadioButton, ComboBoxDropDown comboBoxDropDown) : base(myRadioButton)
            {
                this.comboBoxDropDown = comboBoxDropDown;
                Control.MinimumSize = new Size(comboBoxDropDown.Width, Control.Height);
                Control.Click += Control_Click;
            }
            private void Control_Click(object sender, EventArgs e)
            {
                
            }
        }

        /// <summary>
        /// <c>CheckComboBoxDropDown</c> sınıfı, <seealso cref="System.Windows.Forms.ComboBox"/> kontrolüne tıklanıldığında açılan 
        /// listeyi ifade eder. Bu sınıf <seealso cref="ToolStripDropDown"/> sınıfından türetilmiştir.
        /// </summary>
        internal class ComboBoxDropDown : ToolStripDropDown
        {
            internal System.Windows.Forms.ComboBox comboBox;

            public ComboBoxDropDown(System.Windows.Forms.ComboBox comboBox) : base() => this.comboBox = comboBox;
        }

        /// <summary>
        /// <c>CheckComboBoxCollection</c> sınıfı <seealso cref="RadioButton"/> kontrol koleksiyonunu temsil 
        /// eder. Bu sınıf <seealso cref="List{CustomCheckBox}"/> sınıfından türetilmiştir. Böylelikle tasarım 
        /// anında <seealso cref="Items"/> özelliğine yeni elemanlar eklenebilmesi sağlanır. 
        /// <seealso cref="ComboBoxCollection"/> sınıfını doğrudan <seealso cref="List{T}"/> sınıfından 
        /// türetebilirdik. Yalnız bu durumda birçok metot beraberinde gelecek ve bu metotları yapımıza 
        /// uydurmak için override etmek gerekecekti. Bunun önüne geçmek için <seealso cref="OurList{T}"/> sınıfını
        /// oluşturduk. Böylelikle sadece gerekli metotlar tanımlandı.
        /// </summary>
        [ListBindable(true)]
        public class ComboBoxCollection : OurList<MyRadioButton>
        {
            private readonly ComboBoxDropDown comboBoxDropDown;

            internal ComboBoxCollection(ComboBoxDropDown owner) => comboBoxDropDown = owner;

            /// <summary>
            /// Bu özellik, koleksiyonda içerisinde <paramref name="index"/> ile belirtilen elemana erişime imkan 
            /// verir.
            /// </summary>
            /// <param name="index">Koleksiyon içerisinde erişmek istenilen elemanın indeksi</param>
            /// <returns><seealso cref="MyRadioButton"/> tipinde bir nesne geriye döndürülür.</returns>
            public new MyRadioButton this[int index]
            {
                get => (comboBoxDropDown.Items[index] as ToolStripRadioButton).Control as MyRadioButton;
                set { }
            }

            /// <summary>
            /// Bu metot, <paramref name="item"/> ile belirtilen elemanı koleksiyonun sonuna ekler.
            /// </summary>
            /// <param name="item">Koleksiyona eklenecek elemanı temsil eder.</param>
            /// <returns>Yeni eklenen elemanın koleksiyondaki indeksini belirtir.</returns>
            /// <exception cref="ArgumentNullException"></exception>
            public int Add(MyRadioButton item)
            {
                base.Add(item);
                return comboBoxDropDown.Items.Add(new ToolStripRadioButton(item, comboBoxDropDown));
            }
            public new void Clear()
            {
                base.Clear();
                comboBoxDropDown.Items.Clear();
            }

        }

        /// <summary>
        /// Bu sınıf tasarım anında kontrol ile ilgili tasarım anındaki kullanıcı kontrollerini belirlemektedir.
        /// </summary>
        internal class ComboBoxDesigner : ControlDesigner
        {
            ComboBoxDesigner() => base.AutoResizeHandles = true;

            public override SelectionRules SelectionRules => SelectionRules.LeftSizeable | SelectionRules.RightSizeable | SelectionRules.Moveable;
        }
    }
}
