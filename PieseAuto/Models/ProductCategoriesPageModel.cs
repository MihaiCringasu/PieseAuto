using Microsoft.AspNetCore.Mvc.RazorPages;
using PieseAuto.Data;

namespace PieseAuto.Models
{
    public class ProductCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(PieseAutoContext context,
        Book book)
        {
            var allCategories = context.Category;
            var ProductCategories = new HashSet<int>(
            book.ProductCategories.Select(c => c.CategoryID)); //
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {

                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = ProductCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdateBookCategories(PieseAutoContext context,
        string[] selectedCategories, Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.ProductCategories = new List<ProductCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
            (bookToUpdate.ProductCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.ProductCategories.Add(
                        new ProductCategory
                        {
                            ID = bookToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        ProductCategory bookToRemove
                        = bookToUpdate
                        .ProductCategories
                       .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(bookToRemove);
                    }
                }
            }
        }
    }
}
