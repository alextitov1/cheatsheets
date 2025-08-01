# Job

```sh
oc create job --dry-run=client -o yaml test \
  --image=registry.access.redhat.com/ubi8/ubi:8.6 \
  -- curl https://example.com
```


# CronJob

```sh
oc create cronjob --dry-run=client -o yaml test \
  --image=registry.access.redhat.com/ubi8/ubi:8.6 \
  --schedule='0 0 * * *' \
  -- curl https://example.com
```
config map for CronJob

```yaml
apiVersion: v1
kind: ConfigMap
metadata:
  name: maintenance
  labels:
    ge: appsec-prune
    app: crictl
data:
  maintenance.sh: |
    #!/bin/bash -eu
    NODES=$(oc get nodes -o=name)
    for NODE in ${NODES}
    do
      echo ${NODE}
      oc debug ${NODE} -- \
        chroot /host \
          /bin/bash -euxc 'crictl images ; crictl rmi --prune'
    done
```