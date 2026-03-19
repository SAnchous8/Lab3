open System


//let minDigit n =
//    let rec getDigits num currentMin =
//        if num = 0 then 
//            currentMin
//        else
//            let digit = num % 10
//            getDigits (num / 10) (min digit currentMin)
//    if n = 0 then 
//        0 
//    else 
//        getDigits n 9

//let readNumber index =
//    printf "Число %d: " index
//    let input = int(Console.ReadLine())
//    if input <= 0 then
//        printf "Ошибка, число должно быть натуральным"
//        printfn ""
//        -1
//    else
//        input

//[<EntryPoint>]
//let main arg =
//    printf "Сколько чисел будете вводить? "
//    let count = int(Console.ReadLine())
    
//    let numbers = seq { for i in 1..count do 
//                            yield readNumber i }
    
//    printfn "Исходная последовательность:\n%A" (Seq.map minDigit numbers)
    
//    0




//// Функция для проверки, содержит ли число заданную цифру
//let containsDigit number digit =
//    let rec checkDigits num =
//        if num = 0 then 
//            0
//        else
//            let currentDigit = num % 10
//            if currentDigit = digit then
//                1
//            else
//                checkDigits (num / 10)
    
//    if number = 0 then
//        if digit = 0 then 
//            1 
//        else 
//            0
//    else
//        checkDigits number

//// Функция для чтения одного числа
//let readNumber index =
//    printf "Число %d: " index
//    int(Console.ReadLine())

//[<EntryPoint>]
//let main arg =
//    printf "Сколько чисел будете вводить? "
//    let count = int(Console.ReadLine())
    
//    let numbers = seq { for i in 1..count do 
//                            yield readNumber i }
    
//    printf "Какую цифру ищем? "
//    let targetDigit = int(Console.ReadLine())
    
//    if targetDigit >= 0 && targetDigit <= 9 then
//        printfn "Последовательность"
//        let result = Seq.fold (fun acc number -> acc + (containsDigit number targetDigit)) 0 numbers
        
//        printfn "Количество элементов, содержащих цифру %d: %d" targetDigit result
//    else
//        printf "Ошибка: цифра должна быть от 0 до 9"
    
//    0


open System.IO

let findShortestFileName directoryPath =
    if Directory.Exists(directoryPath) then
        let files = Directory.EnumerateFiles(directoryPath)
        
        if Seq.length files > 0 then
            let names = Seq.map (fun (f: string) -> Path.GetFileNameWithoutExtension(f)) files
            let shortest = Seq.minBy (fun (n: string) -> n.Length) names
            printfn "Самое короткое название файла: %s" shortest
            shortest
        else
            printfn "В каталоге нет файлов"
            ""
    else
        printfn "Каталог '%s' не существует" directoryPath
        ""

[<EntryPoint>]
let main argv =
    printfn "Введите путь к каталогу: "
    let path = Console.ReadLine()
    let result = findShortestFileName path
    
    if result <> "" then
        printfn "Результат: %s" result
        0
    else
        printfn "Не удалось найти файл"
        0
