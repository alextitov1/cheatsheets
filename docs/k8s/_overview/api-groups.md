# API Groups

Kubernetes API is divided into multiple API groups. Each group has its own set of resources and endpoints.

[Official docs](https://kubernetes.io/docs/reference/generated/kubernetes-api/v1.34/#pod-v1-core)

## /version
```sh
kubectl proxy
curl -k http://127.0.0.1:8001
curl -k http://127.0.0.1:8001/version
```

## /metrics
## /healthz
## /logs

## /api (core group)
Old api group

* `/v1`
    - namespaces
    - pods
    - services
    - replicationcontrollers
    - nodes
    - ....

## /apis (named groups)
New, more organized

* `/apis`
    - `/apps` (a group)
        * `/v1`
            - /deployments (a resource)
                - list (verb)
                - get (verb)
                - create (verb)
                - update (verb)
                - delete (verb)
            - /daemonsets
            - /statefulsets
            - /replicasets
    - `/networking.k8s.io`
        * `/v1`
            - /networkpolicies
            - /ingresses
    - `/rbac.authorization.k8s.io`
        * `/v1`
            - /roles
            - /rolebindings
            - /clusterroles
            - /clusterrolebindings
    - `/apiextensions.k8s.io`
        * `/v1`
            - /customresourcedefinitions (CRD)
    - ...