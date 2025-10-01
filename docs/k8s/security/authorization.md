# Authorization Modes

Authorization mode is set via `--authorization-mode` flag on the kube-apiserver. Multiple modes can be specified, and they are evaluated **in order**.

```sh
ExecStart=/usr/local/bin/kube-apiserver \
  --authorization-mode=Node,RBAC,Webhook,AlwaysAllow \
  --advertise-address=<master-ip> \
  --allow-privileged=true \
    ...
```

## AlwaysAllow

## AlwaysDeny

## Node Authorization

**kubelet** ==> **kube-apiserver** authorized via `Node Authorizer`.

The node's certificate CN must be in the format `system:node:<nodeName>` and belong to the `system:nodes` group. This identity (client cert) lets the Node Authorizer and the `NodeRestriction` admission plugin tightly scope the kubelet to only list/watch or mutate objects tied to pods scheduled on that node (e.g. its own Pods, referenced Secrets/ConfigMaps, node/volume status). Any broader access still requires explicit RBAC bindings; the node cert alone does not grant cluster‑wide privileges.

## Attribute-Based Access Control (ABAC)

One policy per user or group. Inconvenient to manage at scale, so mostly deprecated in favor of RBAC.


## Role-Based Access Control (RBAC)

Create a role with specific permissions and bind it to a user or group.

```yaml
# role.yaml
apiVersion: rbac.authorization.k8s.io/v1
kind: Role
metadata:
    namespace: default
rules:
- apiGroups: [""] # "" indicates the core API group
    resources: ["pods"]
    verbs: ["get", "watch", "list"]
```

```yaml
# rolebinding.yaml
apiVersion: rbac.authorization.k8s.io/v1
kind: RoleBinding
metadata:
    name: read-pods
    namespace: default
subjects:
- kind: User
  name: jane
  apiGroup: rbac.authorization.k8s.io
roleRef:
  kind: Role
  name: pod-reader
  apiGroup: rbac.authorization.k8s.io
```


## Webhook
External service called to authorize requests. More complex but very flexible.

for example, you can use [Open Policy Agent (OPA)](https://www.openpolicyagent.org/) as an external authorization service.