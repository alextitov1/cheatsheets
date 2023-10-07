# Config map reloader
Lab 8.4

```yaml
apiVersion: apps/v1
kind: Deployment
metadata:
  name: config-app
  namespace: appsec-api
  annotations:
   configmap.reloader.stakater.com/reload: "config-app"
spec:
...output omitted...
```