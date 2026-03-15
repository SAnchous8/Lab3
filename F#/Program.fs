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
    
//    let numbers = [ for i in 1..count do 
//                        yield readNumber i ]
    
//    let minDigits = Seq.map minDigit numbers
    
//    printfn "\nИсходная последовательность: %A" numbers
//    printfn "Вторая последовательность (минимальные цифры): %A" minDigits
    
//    0




// Функция для проверки, содержит ли число заданную цифру
let containsDigit number digit =
    let rec checkDigits num =
        if num = 0 then 
            0
        else
            let currentDigit = num % 10
            if currentDigit = digit then
                1
            else
                checkDigits (num / 10)
    
    if number = 0 then
        if digit = 0 then 1 else 0
    else
        checkDigits number

// Функция для чтения одного числа
let readNumber index =
    printf "Число %d: " index
    int(Console.ReadLine())

[<EntryPoint>]
let main arg =
    printf "Сколько чисел будете вводить? "
    let count = int(Console.ReadLine())
    
    let numbersList = [ for i in 1..count do 
                            yield readNumber i ]
    
    let numbersSeq = seq { for n in numbersList do
                               yield n }
    
    printfn "\nИсходный список: %A" numbersList
    
    printf "Какую цифру ищем? "
    let targetDigit = int(Console.ReadLine())
    
    if targetDigit >= 0 && targetDigit <= 9 then
        let result = Seq.fold (fun acc number -> acc + (containsDigit number targetDigit)) 0 numbersSeq
        
        printfn "Количество элементов, содержащих цифру %d: %d" targetDigit result
    else
        printf "Ошибка: цифра должна быть от 0 до 9"
    
    0