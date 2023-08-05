# Ch.1 Declarative Resource Management

Creating a starting point for a manifest files:

* use the YAML view of a resource from the web console.
* use imperative commands with the `--dry-run=client` option to generate manifests.
*  `kubectl explain deployment.spec.template.spec` command provides the details for any field in the manifest.

```sh
kubectl create deployment hello-openshift -o yaml \
  --image registry.ocp4.example.com:8443/redhattraining/hello-world-nginx:v1.0 \
  --save-config \
  --dry-run=client \
# --save-config adds configuration attributes that declarative commands use
# --dry-run=client prevents the command from creating resources in the cluster
```
>  to create a resource, use the `kubectl create -f resource.yaml` command

```sh
kubectl create -R -f ~/my-app
# -R option process files recursively in multiple subdirectories
```

> `kubectl apply` command can create and update resources.

Updating resources is more complex than creating resources. The `kubectl apply` writes the contents fo the configuration file to the kubectl.kubernetes.io/last-applied-configuration annotation. The `kubectl create` can also generate this annotation by using the `--save-config` option.

## YAML Validation

* The `--dry-run=server` submits a server-side request without persisting the resource.
* The `--dry-run=client` prints only the object that would be sent to the server.
* The `--validate=true` uses a schema to validate the input and fails the request if it is invalid.

## Compare Resources

`kubectl diff` prints differences between live objects and manifests.

## Update Considerations

If update does not generate new pods, e.g. if only a secret and/or a config map were updated, when changes won't reach the pods. Because pods read secret and configuration maps at startup.

As a solution use `oc rollout restart deployment deployment-name` command to force a restart of the pods.

## Applying Changes

`kubectl apply` command compares three sources to determine how to process the request.
* The manifest file
* The live configuration of the resource in the cluster
* The configuration that is stored in the last-applied-configuration

If the specified resource in the manifest file does not exist, then the `kubectl apply` command creates the resource.

If any fields in the `last-applied-configuration` annotation of the live resource are not present in the manifest, then command removes those fields from the live configuration.

After applying changes to the live resource, the `kubectl apply` command updates the `last-applied-configuration`.

When creating a resource, the `--save-config` option of the `kubectl create` command produce the required annotations for future `kubectl apply` command to operate.

# Kustomize
> apiVersion: kustomize.config.k8s.io/v1beta1

Kustomize - is a command-line configuration manager for Kubernetes objects.

Kustomize works on directories that contain a `kustomization.yaml` file at the root. Kustomize has a concept of *base* and *overlays*

## Base

A base directory contains a `kustomization.yml` file.

```
# a structure of base directory
base
├── configmap.yaml
├── deployment.yaml
├── secret.yaml
├── service.yaml
├── route.yaml
└── kustomization.yaml
overlay
└── development
    └── kustomization.yaml
└── testing
    └── kustomization.yaml
└── production
    ├── kustomization.yaml
    └── patch.yaml
```

```yaml
# kustomization.yml
apiVersion: kustomize.config.k8s.io/v1beta1
kind: Kustomizatio
resources:
- configmap.yaml
- deployment.yaml
- secret.yaml
- service.yaml
- route.yaml
```

# Overlays

Kustomize overlays declarative YAML artifacts, or patches, that override the general settings without modifying the original files.

The overlay directory contains a *kustomization.yaml* file. The kustomization.yaml file can refer to one or more directories as bases.

Multiple overlays can use a common base kustomization directory.


NOT FINISHED


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