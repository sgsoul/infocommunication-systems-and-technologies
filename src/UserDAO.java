import java.util.ArrayList;
import java.util.List;

public class UserDAO {
    private List<User> userList;

    public UserDAO() {
        userList = new ArrayList<>();
    }

    public void addUser(User user) {
        userList.add(user);
    }

    public User getUserById(int id) {
        for (User user : userList) {
            if (user.getId() == id) {
                return user;
            }
        }
        return null;
    }

    public void updateUser(User updatedUser) {
        for (User user : userList) {
            if (user.getId() == updatedUser.getId()) {
                user.setName(updatedUser.getName());
                user.setPosition(updatedUser.getPosition());
                user.setAccessLevel(updatedUser.getAccessLevel());
                break;
            }
        }
    }

    public void deleteUser(int id) {
        User userToRemove = null;
        for (User user : userList) {
            if (user.getId() == id) {
                userToRemove = user;
                break;
            }
        }
        if (userToRemove != null) {
            userList.remove(userToRemove);
        }
    }

    public List<User> getAllUsers() {
        return userList;
    }
}
