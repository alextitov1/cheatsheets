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
# kustomization.yml (base direcotry)
apiVersion: kustomize.config.k8s.io/v1beta1
kind: Kustomizatio
resources:
- configmap.yaml
- deployment.yaml
- secret.yaml
- service.yaml
- route.yaml
```

## Overlays

Kustomize overlays declarative YAML artifacts, or patches, that override the general settings without modifying the original files.

The overlay directory contains a *kustomization.yaml* file. The kustomization.yaml file can refer to one or more directories as bases.

Multiple overlays can use a common base kustomization directory.

```yaml
# kustomization.yaml (overlays/development directory)
apiVersion: kustomize.config.k8s.io/v1beta1
kind: Kustomization
namespace: dev-env
bases:
- ../../base
# uses the base kustomization file at ../../base to create all the application resources in the dev-env namespace
```

Kustomize provides fields to set values for all resources in the kustomization file:

| Field	| Description |
| -- | -- |
| namespace | Set a specific namespace for all resources.
| namePrefix | Add a prefix to the name of all resources.
| nameSuffix | Add a suffix to the name of all resources.
| commonLabels	| Add labels to all resources and selectors.
| commonAnnotations	| Add annotations to all resources and selectors.

The *patches* mechanism has two elements: *patch* and *target*.

```yaml
# kustomization.yaml (overlays/testing)
apiVersion: kustomize.config.k8s.io/v1beta1
kind: Kustomization
namespace: test-env
patches: # The patches field contains a list of patches.
- patch: |-
    - op: replace  ## The patch field defines operation, path, and value keys. In this example, the name changes to frontend-test
      path: /metadata/name
      value: frontend-test
  target: # The target field specifies the kind and name of the resource to apply the patch. In this example, you are changing the frontend deployment name to frontend-test.
    kind: Deployment
    name: frontend
- patch: |- # This patch updates the number of replicas of the frontend deployment.
    - op: replace
      path: /spec/replicas
      value: 15
  target:
    kind: Deployment
    name: frontend
bases: # The frontend-app/overlay/testing/kustomization.yaml file uses the base kustomization file at ../../base to create an application.
- ../../base
commonLabels: # The commonLabels field adds the env: test label to all resources.
  env: test
```

The patches mechanism also provides an option to include patches from a separate YAML file by using the path key.


```yaml
# kustomization.yaml uses a patch.yaml file
apiVersion: kustomize.config.k8s.io/v1beta1
kind: Kustomization
namespace: prod-env
patches: 
- path: patch.yaml # The path field specifies the name of the patching YAML file.
  target:
    kind: Deployment
    name: frontend
  options:
    allowNameChange: true # The allowNameChange field enables kustomization to update the name by using a patch YAML file.
bases:
- ../../base
commonLabels:
  env: prod
```

```yaml
# patch.yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: frontend-prod # The metadata.name field in the patch file updates the frontend deployment name to frontend-prod if the allowNameChange field is set to true in the kustomization YAML file.
spec:
  replicas: 5
```

# View and Deploy Resources by Using Kustomize

`kubectl kustomize <kustomization-directory>` - command to render the manifests without applying them to the cluster

`kubectl apply -k overlay/production` - comman applies a kustomization with the **-k** flag

`oc delete kustomize <kustomization-directory>` - command to delete the resources that were deployed by using Kustomize

# Kustomize Generators

Kustomize has *configMapGenerator* and *secretGenerator* fields that generate configuration map and secret resources.

Generators help to manage the content of configuration maps and secrets, by taking care of encoding and including content from other sources.

## Configuration Map Generator