import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

class Main {
    public static void main(String[] args) throws IOException {
        int key = 123; // искомый ключ
        String fileName = "records.txt"; // имя файла с данными
        boolean found = false;

        BufferedReader reader = new BufferedReader(new FileReader(fileName));
        String line;

        while ((line = reader.readLine()) != null) {
            String[] fields = line.split(";");
            int id = Integer.parseInt(fields[0]);
            if (id == key) {
                System.out.println(line);
                found = true;
                break;
            }
        }

        if (!found) {
            System.out.println("Запись с ключом " + key + " не найдена.");
        }

        reader.close();
    }
}