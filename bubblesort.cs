// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Nhap so phan tu cua mang: ");
//         int n = int.Parse(Console.ReadLine());

//         int[] arr = new int[n];

//         // Nhập các phần tử của mảng
//         Console.WriteLine("Nhap cac phan tu cua mang:");
//         for (int i = 0; i < n; i++)
//         {
//             Console.Write($"Phan tu thu {i + 1}: ");
//             arr[i] = int.Parse(Console.ReadLine());
//         }

//         // Bubble sort
//         BubbleSort(arr);

//         // In mảng sau khi sắp xếp
//         Console.WriteLine("Mang sau khi sap xep:");
//         foreach (int num in arr)
//         {
//             Console.Write(num + " ");
//         }

//         Console.ReadLine();
//     }

//     static void BubbleSort(int[] arr)
//     {
//         int n = arr.Length;
//         for (int i = 0; i < n - 1; i++)
//         {
//             for (int j = 0; j < n - i - 1; j++)
//             {
//                 if (arr[j] > arr[j + 1])
//                 {
//                     // Hoán đổi giá trị
//                     int temp = arr[j];
//                     arr[j] = arr[j + 1];
//                     arr[j + 1] = temp;
//                 }
//             }
//         }
//     }
// }