# Instructions to Run the backend

## Add environment variables for the database

1. Use the `questionnaire.sql` file to create the database and tables in your MySQL database.

2. Refer to the required environment variables for the database which are in the `.env` file in the root directory.

3. Please add those variables with the appropriate values of your database.

### Use AWS RDS database instance instead

We have an AWS RDS database instance that you can use instead. For that please change the following values for the environment variables.

MYSQL_HOST=kurrshanth-db1.crg64q228anw.us-east-1.rds.amazonaws.com
MYSQL_PASSWORD=Kurru4252
MYSQL_USER=root

## Run the backend

1. This application is built with Java 21. Verify if Java 21 is installed on your system. If not, please install it. Use the command `java -`version`and`javac -version` to check the version.

2. Use any IDE like `IntelliJ IDEA` to open the project and add the above-mentioned environment variables.

3. Run the main class `BackEndApplication.java` to start the backend server.
