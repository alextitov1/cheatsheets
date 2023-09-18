# Subjects
* Create a project template that sets quotas, ranges, and network policies.
* Restrict access to the self-provisioners cluster role.
* Create groups and assign users to groups.
* Use role-based access control (RBAC) to grant permissions to groups.

# Lab1

```sh
oc login -u admin -p redhatocp https://api.ocp4.example.com:6443
```

## Create the groups with the specified users:
* Group: **Platform**; Users: **do280-platform**
* Group: **presenters**; Users: **do280-presenter**
* Group: **workshop-support**; Users: **do280-support**

```sh
# Create the workshop-support group
oc adm groups new workshop-support
oc adm groups add-users workshop-support do280-support

# Create the presenters group
oc adm groups new presenters
oc adm groups add-users presenters do280-presenter

# Create the platform group
oc adm groups new platform
oc adm groups add-users platform do280-platform

```
## The `platform` group administers the cluster.
### Solution
Create a cluster role binding to assign the cluster-admin cluster role to the platform group.

```sh
oc adm policy add-cluster-role-to-group cluster-admin platform
```

## The `presenters` group defines the people who deliver the workshops.

## The `workshop-support` group maintains the needed applications to support the workshops and the workshop presenters.



## Ensure that only users from the following groups can create projects:
* platform
* presenters
* workshop-support

## An attendee must not be able to create projects. Because this exercise requires steps that restart the Kubernetes API server, this configuration must persist across API server restarts.

## The workshop-support group requires the following roles in the cluster:

* The admin role to administer projects

* A custom role that is provided in the groups-role.yaml file You must create this custom role to enable support members to create workshop groups and to add workshop attendees.

### Solution
Grant to the `workshop-support` group the `admin` and the custom `manage-groups` cluster roles. You must create the `manage-groups` custom cluster role from the `groups⁠-⁠role⁠.⁠yaml` file.

## The `platform` group must be able to administer the cluster without restrictions.

## The workshop-support group must perform the following tasks for the workshop project:
* Create a workshop-specific attendees group.
* Assign the edit role to the attendees group.
* Add users to the attendees group. 

## Workshop self-service specification:
* Each workshop must be hosted in an independent project.
* All resources that the cluster creates with a new workshop project must have the `workshop` name for grading purposes.

* Each workshop must enforce the following maximum constraints:
  * The project uses up to 2 CPUs.
  * The project uses up to 1 Gi of RAM.
  * The project requests up to 1.5 CPUs.
  * The project requests up to 750 Mi of RAM.

* Each workshop must enforce constraints to prevent an attendee's workload from consuming all the allocated resources for the workshop:
  * A workload uses up to 750m CPUs.
  * A workload uses up to 750 Mi.

* Each workshop must have a resource specification for workloads:
  * A default limit of 500m CPUs.
  * A default limit of 500 Mi of RAM.
  * A default request of 0.1 CPUs.
  * A default request of 250 Mi of RAM.

You can use the templates that are provided in the quota.yaml, limitrange.yaml, and networkpolicy.yaml files.

* Each workshop project must have this additional default configuration:
  * A local binding for the presenter group to the admin cluster role with the workshop name
  * The workshop=project_name label to help to identify the workshop workload
  * Must accept traffic only from within the same workshop or from the ingress controller.

* As the `do280-presenter` user, you must create a workshop with the do280 name.

* As the `do280-support` user, you must create the do280-attendees group with the do280-attendee user.

* Use the registry.ocp4.example.com:8443/redhattraining/hello-world-nginx:v1.0 image, which listens on the 8080 port, to simulate a workshop workload.