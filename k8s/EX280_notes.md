


# Ch.2 Deploy Packaged Applications

## OpenShift Templates
> apiVersion: template.openshift.io/v1

`Template` resource is a Kubernetes extension that Red Hat for OpenShift provides.

`The Cluster Samples Operator` populates templates (and image streams) in the openshift namespace.

```sh
oc get templates -n openshift
```

```sh
# to evaluate any template (cache-service in the example)
oc describe template cache-service -n openshift

# to view only the parameters that a template uses.
oc process --parameters cache-service -n openshift

# template in the file
oc process --parameters -f  my-cache-service.yaml

# to view the manifest for a template
oc get template cache-service -o yaml -n openshift
```

### Using Templates

#### The `oc new-app` command has a --template option

```sh
oc new-app --template=cache-service -p APPLICATION_USER=my-user
```

#### The `oc process` command

Generate a YAML manifest from a template
```sh
oc process my-cache-service \
  -p APPLICATION_USER=user1 -o yaml > my-cache-service-manifest.yaml
# -p parameter
```

Pass parameters in the file
```
# my-cache-service-params.env file
TOTAL_CONTAINER_MEM=1024
APPLICATION_USER='cache-user'
APPLICATION_PASSWORD='my-secret-password'
```
```sh
oc process my-cache-service -o yaml \
  --param-file=my-cache-service-params.env > my-cache-service-manifest.yaml
```

### Managing Templates

For production usage, make a customized copy of the templates.
Make a copy of a template
```sh
oc get template cache-service -o yaml \
  -n openshift > my-cache-service.yaml
```

Upload a template to a current project
```sh
oc create -f my-cache-service.yaml
```

## Helm

Helm is an open source application that helps to manage the lifecycle of K8s applications.

Helm chart is a package that describes a set of K8s resources to deploy.

Helm includes functions to distribute charts and updates.