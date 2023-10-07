# Configure the HTPasswd identity provider
Labs: 3.2

## Delete kubadmin

```sh
oc delete secret kubeadmin -n kube-system
```

## spec
```yaml
apiVersion: config.openshift.io/v1
kind: OAuth
metadata:
  name: cluster
spec:
  identityProviders:
  - name: my_htpasswd_provider
    mappingMethod: claim
    type: HTPasswd
    htpasswd:
      fileData:
        name: htpasswd-secret
```
```sh
oc get oauth cluster -o yaml > oauth.yaml
oc replace -f oauth.yaml
```

## htpasswd
```sh
htpasswd -c -B -b /tmp/htpasswd student redhat123
```

## secret
```sh
oc create secret generic htpasswd-secret --from-file htpasswd=/tmp/htpasswd -n openshift-config

oc extract secret/htpasswd-secret -n openshift-config --to /tmp/ --confirm

oc set data secret/htpasswd-secret --from-file htpasswd=/tmp/htpasswd -n openshift-config
```

# RBAC

## Disable project self-provsioning

```sh
oc adm policy remove-cluster-role-from-group self-provisioner system:authenticated:oauth
```

## Default Roles

* admin
* cluster-admin
* basic-user
* edit
* self-provisioner
* view
* cluster-status


```sh
oc policy add-role-to-user role-name username -n project


oc adm groups new lead-developers <add username>


```

## Troubleshooting

```sh
oc get clusterrolebinding -o wide | grep -E 'NAME|self-provisioner'
oc describe clusterrolebindings self-provisioners
```

```sh
oc adm policy who-can get pod -n project
```

