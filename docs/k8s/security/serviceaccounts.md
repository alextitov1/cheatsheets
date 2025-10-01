# Service Accounts

A service account used by application to interact with the Kubernetes API.


```sh
# imperative way
kubectl create serviceaccount dashboard-sa

kubectl create rolebinding dashboard-sa-view --clusterrole=view --serviceaccount=default:dashboard-sa

# set service account for deployment
kubectl set serviceaccount deploy/web-dashboard dashboard-sa 

# generate token for service account
kubectl create token dashboard-sa
```
decode token
```sh
https://jwt.io

jq -R 'split(".") | select(length > 0) | .[0],.[1] | @base64d | fromjson' <<< "<token>"
```

## Under the hood

1. Service account object created ==> 2. Token generated ==> 3. Token stored in a secret ==> 4. Secret mounted into pods into `/var/run/secrets/kubernetes.io/serviceaccount`

## changes in 1.24+

From v1.24, service account tokens are no longer auto-generated and mounted into pods by default. This is to enhance security by reducing the attack surface.

