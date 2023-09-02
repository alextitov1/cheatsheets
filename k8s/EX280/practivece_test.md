1. Log in to the OpenShift web console as the admin user.
2. Add htpasswd entries to the localusers secret for users named dba and tester using redhat as the password.
3. Create a new app-team group that contains the developer and dba users.
4. Create a new console-review project with a view role binding for the tester user and an edit role binding for the app-team group. Set a resource quota that limits the project to two pods.
5. As the dba user, deploy a MySQL Database instance into the console-review project. Set database as the app name and famous as the username, password and database name. Use the registry.redhat.io/rhel8/mysql-80:1 image.
6. As the developer user, create a deployment, service, and route in the console-review project with issues that you will troubleshoot in the next step. Use the quay.io/redhattraining/famous-quotes:2.1 image, two replica, and name all of the new resources famous-quotes. When correctly configured, the famous-quotes application connects to the MySQL database and displays a list of famous quotes.
Specify the following environment variables in the deployment:
QUOTES_HOSTNAME = database
QUOTES_USER = famous
QUOTES_DATABASE = famous
QUOTES_PASSWORD = famous
7. Troubleshoot and fix the deployment issues.
8. Navigate to the famous-quotes website in a browser and observe the working application.

1. Configure HTPasswd Identity Provider  
2. Configure Cluster permissions 
3. Configure Project permissions 
4. Create Groups and configure permissions