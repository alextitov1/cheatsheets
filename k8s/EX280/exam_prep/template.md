# Create a default template

```sh
oc adm create-bootstrap-project-template \
  -o yaml > project-template.yaml
```

```sh
oc edit projects.config.openshift.io cluster

# apiVersion: config.openshift.io/v1
# kind: Project
# metadata:
# ...output omitted...
#   name: cluster
# ...output omitted...
# spec:
#   projectRequestTemplate:
#     name: project-request
```

```sh
watch oc get pod -n openshift-apiserver
```