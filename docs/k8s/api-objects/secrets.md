````markdown
# Secrets

Kubernetes Secrets are used to store sensitive information, such as passwords, OAuth tokens, SSH keys, etc. They are designed to hold small amounts of sensitive data that you do not want to expose in your application code or configuration files.

Secrets can be created from literal values, files, or directories.

```sh
# Create a secret from literal values
kubectl create secret generic my-secret --from-literal=username=myuser --from-literal=password=mypassword

# Create a secret from a file
kubectl create secret generic my-secret --from-file=ssh-privatekey=/path/to/private/key
```

# Example Secret YAML
```yaml
# secret.yaml
apiVersion: v1
kind: Secret
metadata:
  name: my-secret
type: Opaque  # Default type for generic secrets
data:
  username: bXl1c2Vy  # Base64 encoded value of 'myuser'
  password: bXlwYXNzd29yZA==  # Base64 encoded value of 'mypassword'
```
Base64 encoding
```sh
# Encode a string to Base64
echo -n 'myuser' | base64  # Output: bXl1cmVy
echo -n 'mypassword' | base64  # Output: bXlwcGFzc3dvcmQ=
```

# Use Secret in a Pod
```yaml
# pod-with-secret.yaml
apiVersion: v1
kind: Pod
metadata:
  name: my-pod
spec:
  containers:
  - name: my-container
    image: nginx
    env:
    - name: USERNAME
      valueFrom:
        secretKeyRef:
          name: my-secret  # Reference to the Secret
          key: username  # Key in the Secret
    - name: PASSWORD
      valueFrom:
        secretKeyRef:
          name: my-secret  # Reference to the Secret
          key: password  # Key in the Secret
  volumes:
  - name: secret-volume
    secret:
      secretName: my-secret  # Reference to the Secret
  volumeMounts:
  - name: secret-volume
    mountPath: /etc/secret-volume  # Path where the secret will be mounted
    readOnly: true  # Mount as read-only
````
