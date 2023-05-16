import java.util.List;
import java.util.Scanner;

public class UserView {
    private UserController userController;
    private Scanner scanner;

    public UserView(UserController userController) {
        this.userController = userController;
        scanner = new Scanner(System.in);
    }

    public void displayMenu() {
        System.out.println("==== User Management System ====");
        System.out.println("1. Add User");
        System.out.println("2. Update User");
        System.out.println("3. Delete User");
        System.out.println("4. View User by ID");
        System.out.println("5. View All Users");
        System.out.println("0. Exit");
        System.out.println("=================================");
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
                    addUser();
                    break;
                case 2:
                    updateUser();
                    break;
                case 3:
                    deleteUser();
                    break;
                case 4:
                    viewUserById();
                    break;
                case 5:
                    viewAllUsers();
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

    private void addUser() {
        System.out.println("Enter the user details:");
        System.out.print("ID: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline character
        System.out.print("Name: ");
        String name = scanner.nextLine();
        System.out.print("Position: ");
        String position = scanner.nextLine();
        System.out.print("Level of access: ");
        String accessLevel = scanner.nextLine();

        User user = new User(id, name, position, accessLevel);
        userController.addUser(user);
    }

    private void updateUser() {
        System.out.print("Enter the ID of the user to update: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline character

        User existingUser = userController.getUserById(id);

        if (existingUser != null) {
            System.out.println("Enter the new details for the user (or leave blank to skip):");
            System.out.print("Name: ");
            String name = scanner.nextLine();
            if (!name.isEmpty()) {
                existingUser.setName(name);
            }
            System.out.print("Position: ");
            String pos = scanner.nextLine();
            if (!pos.isEmpty()) {
                existingUser.setPosition(pos);
            }
            System.out.print("Level of access: ");
            String lvl = scanner.nextLine();
            if (!lvl.isEmpty()) {
                existingUser.setAccessLevel(lvl);
            }

            userController.updateUser(existingUser);
        } else {
            System.out.println("User not found with ID: " + id);
        }
    }

    private void deleteUser() {
        System.out.print("Enter the ID of the user to delete: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline character

        userController.deleteUser(id);
    }

    private void viewUserById() {
        System.out.print("Enter the ID of the user to view: ");
        int id = scanner.nextInt();
        scanner.nextLine(); // Consume newline character

        User user = userController.getUserById(id);

        if (user != null) {
            System.out.println("User Details:");
            System.out.println("ID: " + user.getId());
            System.out.println("Name: " + user.getName());
            System.out.println("Position: " + user.getPosition());
            System.out.println("Level of access: " + user.getAccessLevel());
        } else {
            System.out.println("User not found with ID: " + id);
        }
    }

    private void viewAllUsers() {
        List<User> userList = userController.getAllUsers();

        if (userList.isEmpty()) {
            System.out.println("No users found.");
        } else {
            System.out.println("User List:");
            for (User user : userList) {
                System.out.println("ID: " + user.getId());
                System.out.println("Name: " + user.getName());
                System.out.println("Position: " + user.getPosition());
                System.out.println("Level of access: " + user.getAccessLevel());
                System.out.println("-----------------------");
            }
        }
    }
}