    using app5.Models;
    using System.Collections.ObjectModel;
namespace app5
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Item> Items { get; set; } = new();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Додаємо тестові дані
            Items.Add(new Product
            {
                Name = "Хліб тостовий",
                Price = 30.5m,
                CountryOfOrigin = "Україна",
                PackagingDate = DateTime.Now,
                ShelfLife = 31,
                Quantity = 5,
                Unit = "шт"
            });

            Items.Add(new Book
            {
                Name = "Кобзар",
                Price = 200.99m,
                CountryOfOrigin = "Україна",
                PackagingDate = DateTime.Now,
                Publisher = "Поетичні твори",
                Pages = 500,
                Authors = new List<string> { "Тарас Шевченко" }
            });
        }

        private void OnItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Item selectedItem)
            {
                // Відображаємо додаткову інформацію про вибраний товар
                DetailsView.IsVisible = true;

                if (selectedItem is Product product)
                {
                    DetailsLabel.Text = "Деталі продукту";
                    DetailsContent.Text = $"Термін зберігання: {product.ShelfLife} днів\n" +
                                          $"Кількість: {product.Quantity} {product.Unit}";
                }
                else if (selectedItem is Book book)
                {
                    DetailsLabel.Text = "Деталі книги";
                    DetailsContent.Text = $"Книги: {book.Pages}\n" +
                                          $"Видавництво: {book.Publisher}\n" +
                                          $"Автори: {string.Join(", ", book.Authors)}";
                }
            }
        }

        private async void OnAddItemClicked(object sender, EventArgs e)
        {
            string itemType = await DisplayActionSheet("Виберіть тип елемента", "Скасувати", null, "Продукт", "Книга");

            if (itemType == "Продукт")
            {
                string name = await DisplayPromptAsync("Додати продукт", "Введіть :");
                string priceStr = await DisplayPromptAsync("Додати продукт", "Введіть ціну продукут:");
                string country = await DisplayPromptAsync("Додати продукт", "Введіть країну походженя:");
                string shelfLifeStr = await DisplayPromptAsync("Додати продукт", "Введіть термін придатності продукту в днях:");
                string quantityStr = await DisplayPromptAsync("Додати продукт", "Введіть кількість:");
                string unit = await DisplayPromptAsync("Add Product", "Введіть одиницю вимірювання (наприклад, кг, л):");

                if (decimal.TryParse(priceStr, out decimal price) &&
                    int.TryParse(shelfLifeStr, out int shelfLife) &&
                    int.TryParse(quantityStr, out int quantity))
                {
                    Items.Add(new Product
                    {
                        Name = name,
                        Price = price,
                        CountryOfOrigin = country,
                        PackagingDate = DateTime.Now,
                        ShelfLife = shelfLife,
                        Quantity = quantity,
                        Unit = unit
                    });
                }
                else
                {
                    await DisplayAlert("Помилка", "Невірний вхід. Спробуйте ще раз.", "OK");
                }
            }
            else if (itemType == "Книга")
            {
                string name = await DisplayPromptAsync("Додати книжку", "Введіть назву книжки:");
                string priceStr = await DisplayPromptAsync("Додати книжку", "Введіть ціну:");
                string country = await DisplayPromptAsync("Додати книжку", "Введіть країну походження:");
                string pagesStr = await DisplayPromptAsync("Додати книжку", "Введіть кількість сторінок:");
                string publisher = await DisplayPromptAsync("Додати книжку", "Введіть видавництво:");
                string authors = await DisplayPromptAsync("Додати книжку", "Введіть авторів (через кому):");

                if (decimal.TryParse(priceStr, out decimal price) &&
                    int.TryParse(pagesStr, out int pages))
                {
                    Items.Add(new Book
                    {
                        Name = name,
                        Price = price,
                        CountryOfOrigin = country,
                        PackagingDate = DateTime.Now,
                        Pages = pages,
                        Publisher = publisher,
                        Authors = authors.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(a => a.Trim()).ToList()
                    });
                }
                else
                {
                    await DisplayAlert("Помилка", "Невірний вхід. Спробуйте ще раз.", "OK");
                }
            }
        }


        private void OnDeleteItemClicked(object sender, EventArgs e)
        {
            if (ItemList.SelectedItem != null)
            {
                Items.Remove((Item)ItemList.SelectedItem);
                DetailsView.IsVisible = false;  // Приховуємо додаткову інформацію
            }
        }
    }

}
