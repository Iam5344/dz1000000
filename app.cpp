#include <iostream>
#include <fstream>
#include <cstdlib>
#include <ctime>
using namespace std;

class Game {
private:
    int secretNumber;
    int attempts;
    
public:
    Game() {
        srand(time(0));
        secretNumber = rand() % 500 + 1;
        attempts = 0;
    }
    
    void play() {
        int guess;
        cout << "Угадайте число от 1 до 500" << endl;
        
        while (true) {
            cout << "Введите число: ";
            cin >> guess;
            attempts++;
            
            if (guess < secretNumber) {
                cout << "Загаданное число больше" << endl;
            } else if (guess > secretNumber) {
                cout << "Загаданное число меньше" << endl;
            } else {
                cout << "Поздравляем! Вы угадали за " << attempts << " попыток!" << endl;
                break;
            }
        }
    }
    
    void saveToFile() {
        ofstream file("game_stats.txt", ios::app);
        if (file.is_open()) {
            file << "Число: " << secretNumber << ", Попыток: " << attempts << endl;
            file.close();
        }
    }
    
    int getAttempts() {
        return attempts;
    }
};

class Statistics {
public:
    void show() {
        ifstream file("game_stats.txt");
        if (file.is_open()) {
            cout << "\n=== СТАТИСТИКА ИГР ===" << endl;
            string line;
            int gameNumber = 1;
            while (getline(file, line)) {
                cout << "Игра " << gameNumber << ": " << line << endl;
                gameNumber++;
            }
            file.close();
        } else {
            cout << "Статистика пока пуста" << endl;
        }
    }
};

int main() {
    setlocale(0, "");
    
    while (true) {
        cout << "\n=== ИГРА 'УГАДАЙ ЧИСЛО' ===" << endl;
        cout << "1. Новая игра" << endl;
        cout << "2. Показать статистику" << endl;
        cout << "3. Выход" << endl;
        cout << "Выберите действие: ";
        
        int choice;
        cin >> choice;
        
        if (choice == 1) {
            Game game;
            game.play();
            game.saveToFile();
        } else if (choice == 2) {
            Statistics stats;
            stats.show();
        } else if (choice == 3) {
            break;
        }
    }
    
    return 0;
}
