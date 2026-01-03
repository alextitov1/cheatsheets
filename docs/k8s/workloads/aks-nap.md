AKS Node auto-provisioning (NAP) - enables automatic management of node pools in an Azure Kubernetes Service (AKS) cluster.

it uses policies to define rules for scaling node pools based on workload demands, ensuring optimal resource utilization and cost efficiency.

unlike cluster autoscaler, which adjusts the number of nodes in existing node pools (VMSS), NAP can create and delete individual node without VMSS pools.

AKS NAP is based on Karpenter, an open-source project that provides advanced node provisioning capabilities for Kubernetes clusters.


NodePool and NodeClaims - CRDs used by AKS NAP to manage node pools and their configurations.

NodeClaim - Managed by NAP to represent the current state of provisioned nodes that you can monitor.

## Cluster autoscaler

https://learn.microsoft.com/en-us/azure/aks/cluster-autoscaler-overview

## NAP

https://learn.microsoft.com/en-us/azure/aks/node-auto-provisioning

