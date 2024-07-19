# Harmonia Architecture

## Overview

Harmonia is a microservices-based application designed to demonstrate the integration of various modern technologies. This document provides an overview of the system architecture, including the solution architecture and the Kubernetes deployment architecture.

## Solution Architecture

The Harmonia project consists of multiple microservices, each responsible for specific functionalities. These services communicate using both synchronous and asynchronous messaging patterns.

### Microservices

1. **PlatformService**
    - Manages platform-related data and operations.
    - Provides RESTful API endpoints for creating, reading, updating, and deleting platforms.
    - Publishes platform data events to RabbitMQ for other services to consume.

2. **CommandService**
    - Manages command-related data and operations.
    - Provides RESTful API endpoints for creating, reading, updating, and deleting commands.
    - Consumes platform data events from RabbitMQ to maintain data consistency.

### Communication

- **Synchronous Communication**
  - gRPC: Used for direct, synchronous communication between services when immediate response is required.

- **Asynchronous Communication**
  - RabbitMQ: Used for asynchronous messaging to decouple services and enable event-driven architecture.

### Databases

- Each microservice has its own database to ensure loose coupling and independence.
- Services use Entity Framework Core for data access and management.

### Data Transfer Objects (DTOs)

- DTOs are used to transfer data between services and clients.
- They maintain a clear separation between the internal data models and the data exposed via APIs.

## Kubernetes Architecture

Harmonia is designed to be deployed on Kubernetes, which provides container orchestration and management. This section describes the Kubernetes components used to deploy and manage the Harmonia services.

### Components

1. **Deployments**
    - Define the desired state for each microservice, including the number of replicas and the container image to use.
    - Ensure that the specified number of replicas are running and updated.

2. **Services**
    - Expose the microservices to the network.
    - Types:
        - ClusterIP: Internal communication within the cluster.
        - NodePort: Exposes the service on a port on each node in the cluster.
        - LoadBalancer: Exposes the service externally using a cloud provider's load balancer.

3. **Ingress**
    - Manages external access to the services, typically HTTP/HTTPS.
    - Provides routing rules to direct traffic to the appropriate services based on the request path.

4. **ConfigMaps and Secrets**
    - Store configuration data and sensitive information, respectively.
    - Provide these configurations to the microservices at runtime.

5. **Persistent Volumes and Persistent Volume Claims**
    - Manage storage for stateful applications.

### Deployment Steps

1. **Build and Push Docker Images**
    - Build Docker images for each microservice.
    - Push the images to a container registry (e.g., Docker Hub).

2. **Create Kubernetes Manifests**
    - Define deployments, services, ingress, configmaps, and secrets in YAML files.

3. **Apply Kubernetes Manifests**
    - Use `kubectl apply -f <manifest>` to deploy the components to the cluster.

4. **Set Up Ingress**
    - Define ingress rules to route external traffic to the appropriate services.

## Conclusion

The Harmonia project leverages a combination of microservices architecture, synchronous and asynchronous communication, and Kubernetes for deployment and orchestration. This architecture ensures scalability, flexibility, and maintainability, making it an ideal solution for modern cloud-native applications.
