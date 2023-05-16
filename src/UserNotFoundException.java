public class UserNotFoundException extends Exception {
    private int userId;

    public UserNotFoundException(int userId) {
        super("User not found with ID: " + userId);
        this.userId = userId;
    }

    public int getUserId() {
        return userId;
    }
}

