import java.util.List;
import java.util.Scanner;

public class EquipmentView {
    private EquipmentController equipmentController;
    private Scanner scanner;

    public EquipmentView(EquipmentController equipmentController) {
        this.equipmentController = equipmentController;
        scanner = new Scanner(System.in);
    }

    public void displayMenu() {
        System.out.println("==== Equipment Management System ====");
        System.out.println("1. Add Equipment");
        System.out.println("2. Update Equipment");
        System.out.println("3. Delete Equipment");
        System.out.println("4. View Equipment by ID");
        System.out.println("5. View All Equipment");
        System.out.println("0. Exit");
        System.out.println("======================================");
    }

    public void run() {
        int choice;

        do {
            displayMenu();
            System.out.print("Enter your choice: ");
            choice = scanner.nextInt();
            scanner.nextLine(); // Consume newline character

            switch (choice) {
                case 1:
                    addEquipment();
                    break;
                case 2:
                    updateEquipment();
                    break;
                case 3:
                    deleteEquipment();
                    break;
                case 4:
                    viewEquipmentById();
                    break;
                case 5:
                    viewAllEquipment();
                    break;
                case 0:
                    System.out.println("Exiting the program. Goodbye!");
                    break;
                default:
                    System.out.println("Invalid choice. Please try again.");
                    break;
            }
        } while (choice != 0);
    }

    private void addEquipment() {
        System.out.println("Enter the equipment details:");
        System.out.print("ID: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline character
        System.out.print("Name: ");
        String name = scanner.nextLine();
        System.out.print("Type: ");
        String type = scanner.nextLine();
        System.out.print("Status: ");
        String status = scanner.nextLine();

        Equipment equipment = new Equipment(id, name, type, status);
        equipmentController.addEquipment(equipment);
    }

    private void updateEquipment() {
        System.out.print("Enter the ID of the equipment to update: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline character

        Equipment existingEquipment = equipmentController.getEquipmentById(id);

        if (existingEquipment != null) {
            System.out.println("Enter the new details for the equipment (or leave blank to skip):");
            System.out.print("Name: ");
            String name = scanner.nextLine();
            if (!name.isEmpty()) {
                existingEquipment.setName(name);
            }
            System.out.print("Type: ");
            String type = scanner.nextLine();
            if (!type.isEmpty()) {
                existingEquipment.setType(type);
            }
            System.out.print("Status: ");
            String status = scanner.nextLine();
            if (!status.isEmpty()) {
                existingEquipment.setStatus(status);
            }

            equipmentController.updateEquipment(existingEquipment);
        } else {
            System.out.println("Equipment not found with ID: " + id);
        }
    }

    private void deleteEquipment() {
        System.out.print("Enter the ID of the equipment to delete: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline character

        equipmentController.deleteEquipment(id);
    }

    private void viewEquipmentById() {
        System.out.print("Enter the ID of the equipment to view: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline character

        Equipment equipment = equipmentController.getEquipmentById(id);

        if (equipment != null) {
            System.out.println("Equipment Details:");
            System.out.println("ID: " + equipment.getId());
            System.out.println("Name: " + equipment.getName());
            System.out.println("Type: " + equipment.getType());
            System.out.println("Status: " + equipment.getStatus());
        } else {
            System.out.println("Equipment not found with ID: " + id);
        }
    }

    private void viewAllEquipment() {
        List<Equipment> equipmentList = equipmentController.getAllEquipment();

        if (equipmentList.isEmpty()) {
            System.out.println("No equipment found.");
        } else {
            System.out.println("Equipment List:");
            for (Equipment equipment : equipmentList) {
                System.out.println("ID: " + equipment.getId());
                System.out.println("Name: " + equipment.getName());
                System.out.println("Type: " + equipment.getType());
                System.out.println("Status: " + equipment.getStatus());
                System.out.println("-----------------------");
            }
        }
    }
}


