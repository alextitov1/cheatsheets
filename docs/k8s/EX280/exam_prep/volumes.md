# Volume from secret
```sh
oc set volume deployment/demo --add --type secret \
--secret-name demo-secret --mount-path /app-secrets
```

# Volume from config map
```sh
oc set volume deployment/demo --add --type configmap \
--configmap-name demo-map --mount-path /app-secrets

# to check if volume attached
oc set volume deployment/demo
```

# PVC

```sh
oc set volumes deployment/db-pod \
  --add --type pvc \
  --mount-path /var/lib/mysql \
  --claim-name db-pod-pvc
```

# PV

```sh
showmount -e localhost
```