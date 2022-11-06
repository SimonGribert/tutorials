import UIKit

var ages = [21, 55, 19, 47, 22, 37, 88, 71]

print(ages.count)
print(ages.first!)
print(ages.last!)
print(ages[3])

ages.append(99)
ages.insert(44, at: 2)
print(ages)

//var agesSet: Set<Int> = [];
var agesSet = Set(ages);

agesSet.insert(101)
agesSet.contains(101)

print(agesSet)

let devices: [String: String] = [
    "phone": "iPhone X",
    "laptop": "2016 MacBook Pro",
    "tablet": "2018 iPad Pro",
    "desktop": "2017 iMac Pro",
]

devices["laptop"];

func printInstructors(name: String) {
    print(name)
}

printInstructors(name: "Simon")

func add(firstNumber: Int, to secondNumber: Int) -> Int {
    let sum = firstNumber + secondNumber;
    
    return sum
}

add(firstNumber: 5, to: 10)

var isDarkModeOn = false;

if isDarkModeOn {
    print("That's how it should be")
} else {
    print("That's not how it should be")
}

var myHighScore = 555;
var yourHighScore = 444;

if myHighScore > yourHighScore {
    print("I Win")
} else if yourHighScore > myHighScore {
    print("You Win")
} else {
    print("Draw")
}

let allStars = ["James", "Davis", "Harden", "Doncic", "Leonard"]

for player in allStars where player == "Harden" {
    print(player)
}

var randomInts: [Int] = []

for _ in 0..<25 {
    let randomNumber = Int.random(in: 0...100)
    randomInts.append(randomNumber)
}

print(randomInts)


enum Phone: String {
    case iPhone11Pro = "This will be my next phone."
    case iPhoneSE = "I dislike this phone size."
    case pixel = "Cant break"
    case nokia = "Android???"
}

func getSimonsOpinion2(on phone: Phone) {
    print(phone.rawValue)
}

func getSimonsOpinion(on phone: Phone) {
    switch phone {
    case .nokia:
        print("Cant break")
    case .iPhoneSE:
        print("I dislike this phone size.")
    case .iPhone11Pro:
        print("This will be my next phone.")
    case .pixel:
        print("Android???")
    }
}

// getSimonsOpinion(on: .iPhone11Pro)

let matchmakingRank = 5000;

func determinePlayerLeague(from rank: Int) {
    switch rank {
    case 0:
        print("Play the game")
    case 1..<50:
        print("You are in BRONZE League")
    case 50..<100:
        print("You are in SILVER League")
    case 100..<200:
        print("You are in GOLD League")
    default:
        print("You are in a league of your own")
    }
}

determinePlayerLeague(from: 50)

let valueOne: Float = 55
let valueTwo: Float = 88
let valueThree = 100
let valueFour = 22

let sum = valueOne + valueTwo
let sum2 = valueOne - valueTwo
let sum3 = valueOne * valueTwo
let sum4 = valueOne / valueTwo
let sum5 = valueThree % valueFour

var agesTwo: [Int] = [21, 55, 19, 47, 22, 37, 88, 71]

agesTwo.sort()

if let oldestAge = agesTwo.last {
    print("The oldest age is \(oldestAge)")
} else {
    print("There is no oldest age. You must have no students.")
}

//let oldestAge = agesTwo.last ?? 999

func getOldestAge() {
    guard let oldestAge = agesTwo.last else {
        return
    }
    
    print("The oldest age is \(oldestAge)")
}

getOldestAge()

let oldestAge = agesTwo.last!;

class Developer {
    var name: String?
    var jobTitle: String?
    var yearExp: Int?
    
    init() {}
    
    init(name: String, jobTitle: String, yearExp: Int) {
        self.name = name
        self.jobTitle = jobTitle
        self.yearExp = yearExp
    }
    
    func speakName() {
        print(name!)
    }
}

/*let simon = Developer(name: "Simon", jobTitle: "Full Stack Dev", yearExp: 3)

simon.name
simon.jobTitle
simon.yearExp
simon.speakName()

let sean = Developer()

sean.name = "Sean"
sean.jobTitle = "iOS Dev"
sean.yearExp = 7*/


class iOSDeveloper: Developer {
    var favoriteFramework: String?
    
    func speakFavoriteFramework() {
        guard let favFW = favoriteFramework else {
            print("I dont have a favorite framework")
            return
        }
        
        print(favFW)
    }
    
    override func speakName() {
        print("\(name!) - \(jobTitle!)")
    }
}

let simon = iOSDeveloper(name: "Simon", jobTitle: "Full Stack Dev", yearExp: 3)
simon.favoriteFramework = "ArKit"
simon.speakFavoriteFramework()
simon.speakName()

var joe = simon
joe.name = "Joe"
joe.name
simon.name

struct DeveloperStruct {
    var name: String?
    var jobTitle: String?
    var yearExp: Int?
}

let simonTwo = DeveloperStruct(name: "Simon", jobTitle: "Full Stack Dev", yearExp: 3)
var joeTwo = simonTwo
joeTwo.name = "Joe"
joeTwo.name
simonTwo.name


extension String {
    
    func yoo() -> String {
        return "Yoo"
    }
}

print("This is not Yoo".yoo())


func fizzbuzz() {
    for i in 1...100 {
        if (i % 3 == 0 && i % 5 == 0) {
            print("FIZZBUZZ!")
        } else if (i % 3 == 0) {
            print("FIZZ")
        } else if (i % 5 == 0) {
            print("BUZZ")
        } else {
            print(i)
        }
    }
}

fizzbuzz()
