# Helm

**Release** - a specific deployment of a chart, with a specific configuration.

**Revision** - a specific version of a release. Each time a release is updated, its revision number is incremented. (like a snapshot)


Helm stores its metadata in kubernetes secrets.


## helm cli

```sh
helm version
helm repo add stable https://charts.helm.sh/stable
helm repo update
helm search repo stable

helm search hub mysql # search helm charts in artifacthub.io

helm install my-release stable/mysql --set rootPassword=my-secret-pw,service.type=NodePort,service.port=3306
helm list
helm status my-release
helm upgrade my-release stable/mysql --set rootPassword=new-password
helm rollback my-release 1
helm uninstall my-release

# you can untar helm charts to see their structure
helm pull stable/mysql --untar

# install from from local chart directory
helm install my-release ./mysql-chart-directory
```

## Helm chart concepts

**Chart** - a package (collection of files) of pre-configured Kubernetes resources.

* value.yaml - default configuration values for a chart
* Chart.yaml - metadata about the chart (name, version, description)
* templates/ - directory containing Kubernetes manifest templates

There are 2 types of charts:
* Application charts - deploy an application (e.g., WordPress, MySQL)
* Library charts - provide reusable snippets for other charts


## Helm repositories

> artifactHub.io - repository of Helm charts and other Kubernetes resources.

