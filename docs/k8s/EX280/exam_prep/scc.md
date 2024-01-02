# Security Context Constraints (SCCs)
limit the access from a running pod in OpenShift to the host environment.

```sh
# get help
oc adm policy scc-subject-review -f payroll-app.yaml

# get a list of all SCCs
oc get scc 
oc describe scc anyuid
oc describe pod console-5df4fcbb47-67c52 -n openshift-console | grep scc

# service account is a project entity
oc create serviceaccount service-account-name

# add SCC anyuid to service account
oc adm policy add-scc-to-user anyuid -z service-account

# set the existing deployment to use the service account
oc set serviceaccount deployment deployment-name service-account-name
```
or 
```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  labels:
    app: configmap-reloader
  name: configmap-reloader
  namespace: configmap-reloader
spec:
  selector:
    matchLabels:
      app: configmap-reloader
      release: "reloader"
  template:
    metadata:
      labels:
        app: configmap-reloader
    spec:
      serviceAccountName: configmap-reloader
      containers:
...output omitted...
```

# Allow Application Access to Kubernetes API

Service account from another project
```
system:serviceaccount:project:service-account
```

You can optionally use -z to avoid specifying the `system:serviceaccount:project` prefix when you assign the role to a service account that exists in the **current** project.
```sh
oc adm policy add-role-to-user cluster-role -z service-account
```

```sh
oc adm policy add-role-to-user edit \
   system:serviceaccount:configmap-reloader:configmap-reloader \
   --rolebinding-name=reloader-edit -n appsec-api
```