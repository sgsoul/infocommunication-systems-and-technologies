public class User {
    private int id;
    private String name;
    private String position;
    private String accessLevel;

    public User(int id, String name, String position, String accessLevel) {
        this.id = id;
        this.name = name;
        this.position = position;
        this.accessLevel = accessLevel;
    }

    // Геттеры и сеттеры для всех полей

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getPosition() {
        return position;
    }

    public void setPosition(String position) {
        this.position = position;
    }

    public String getAccessLevel() {
        return accessLevel;
    }

    public void setAccessLevel(String accessLevel) {
        this.accessLevel = accessLevel;
    }

    // Переопределение метода toString() для удобного вывода информации о пользователе

    @Override
    public String toString() {
        return "User{" +
                "id=" + id +
                ", name='" + name + '\'' +
                ", position='" + position + '\'' +
                ", accessLevel='" + accessLevel + '\'' +
                '}';
    }
}
