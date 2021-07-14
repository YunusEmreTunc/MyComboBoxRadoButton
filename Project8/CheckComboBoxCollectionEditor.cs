using System;
using System.ComponentModel.Design;


namespace MyComboBoxRadioButton
{
    /// <summary>
    /// <seealso cref="ComboBoxCollectionEditor"/> sınıfı, <seealso cref="ComboBox"/> kontrolünün <seealso cref="ComboBox.Items"/> özelliğine tasarım esnasında yeni <seealso cref="MyRadioButton"/> kontrolleri eklenmesine imkan tanır.
    /// </summary>
    public class ComboBoxCollectionEditor : CollectionEditor
    {
        public ComboBoxCollectionEditor() : base(type: typeof(ComboBox.ComboBoxCollection)) { }

        protected override object CreateInstance(Type itemType) => new MyRadioButton();
    }
}
