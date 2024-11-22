using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GENERICS
{

    class Program
    {
        static void Main(string[] args)
        {
            DictionaryRepository<int, Product> productRepository = new DictionaryRepository<int, Product>();

            while (true)
            {
                Console.WriteLine("\nSelect an option:");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Get Product");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");
                Console.Write("\nEnter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Product ID: ");
                        if (int.TryParse(Console.ReadLine(), out int addId))
                        {
                            Console.Write("Enter Product Name: ");
                            string addName = Console.ReadLine();
                            Product newProduct = new Product { ProductId = addId, ProductName = addName };

                            try
                            {
                                productRepository.Add(addId, newProduct);
                                Console.WriteLine("---------Product added successfully.-------------");
                            }
                            catch (ArgumentException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please enter a valid integer.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter Product ID to retrieve: ");
                        if (int.TryParse(Console.ReadLine(), out int getId))
                        {
                            try
                            {
                                Product retrievedProduct = productRepository.Get(getId);
                                Console.WriteLine("----------- Retrieved Product ------------- ");
                                Console.WriteLine("\n\t ProductId \t ProductName ");
                                Console.WriteLine($"\t{retrievedProduct.ProductId} \t\t {retrievedProduct.ProductName}");
                            }
                            catch (KeyNotFoundException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID. Please enter a valid integer.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Product ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            try
                            {
                                Product existingProduct = productRepository.Get(updateId);
                                Console.Write("Enter new Product Name (leave blank to keep existing): ");
                                string updateName = Console.ReadLine();

                                // Update only if a new name is provided
                                if (!string.IsNullOrWhiteSpace(updateName))
                                {
                                    existingProduct.ProductName = updateName;
                                }

                                productRepository.Update(updateId, existingProduct);
                                Console.WriteLine("----------Product updated successfully.-------------");

                            }
                            catch (KeyNotFoundException ex)
                            {
                                
                                    Console.WriteLine(ex.Message);       
                            
                            }
                        }

                            break;

                    case "4":

                                Console.Write("Enter Product ID to delete: ");
                                int deleteId = int.Parse(Console.ReadLine());
                                try
                                {
                                    productRepository.Delete(deleteId);
                                    Console.WriteLine("-----------Product deleted successfully.------------");
                                }
                                catch (KeyNotFoundException ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;

                            case "5":

                                Console.WriteLine("--------Exiting the application.--------------");
                                return;

                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                            }
                        } 
                }
            }
        }
    

                
            
        

