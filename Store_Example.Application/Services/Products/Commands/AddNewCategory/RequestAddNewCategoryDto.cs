namespace Store_Example.Application.Services.Products.Commands.AddNewCategory;

public class RequestAddNewCategoryDto
{
	public string Name { get; set; }

	public long? ParentCategoryId { get; set; }
}