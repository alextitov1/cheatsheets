# ConfigMaps

ConfigMaps are Kubernetes objects that allow you to store configuration data in key-value pairs. They can be used to decouple configuration artifacts from image content to keep containerized applications portable.

```sh
kubectl create configmap my-config --from-literal=key1=value1 --from-literal=key2=value2

# Create a ConfigMap from a file
kubectl create configmap my-config --from-file=config.txt
# config.txt content:
## key1=value1
## key2=value2
```

# Example ConfigMap YAML
```yaml
# configmap.yaml
apiVersion: v1
kind: ConfigMap
metadata:
  name: my-config
data:
  key1: value1
  key2: value2
```

# Use ConfigMap in a Pod

```yaml
# (envFrom)pod-with-configmap.yaml
apiVersion: v1
kind: Pod
metadata:
  name: my-pod
spec:
  containers:
  - name: my-container
    image: nginx
    envFrom:
    - configMapRef:
        name: my-config  # Reference to the ConfigMap

# (valueFrom)pod-with-configmap.yaml
apiVersion: v1
kind: Pod
metadata:
  name: my-pod
spec:
  containers:
  - name: my-container
    image: nginx
    env:
    - name: KEY1
      valueFrom:
        configMapKeyRef:
          name: my-config  # Reference to the ConfigMap
          key: key1  # Key in the ConfigMap
```