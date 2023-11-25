# Microservices

This project presents a container-based Docker Compose orchestrated solution for a microservices architecture. It combines various data stores and technologies, all working in synchronization to deliver a cohesive system. The architecture comprises four APIs: Basket API, Discount API, Ordering API, and Catalog API.

## APIs and Data Stores

### Basket API
- **Data Store:** Utilizes Redis cache for data storage.

### Catalog API
- **Data Store:** Relies on MongoDB for data storage.

### Discount API
- **Data Store:** Uses PostgreSQL as its primary data store.

### Ordering API
- **Data Store:** Operates with SQL Server for data storage.

## Messaging and Gateway

### RabbitMQ
- Acts as the messaging platform within the microservices architecture, facilitating communication and event-driven interactions between services.

### Ocelot API Gateway
- Serves as the entry point for the microservices architecture, managing and routing incoming requests to the appropriate services.

## Docker Compose

The project is containerized and orchestrated using Docker Compose, enabling seamless deployment and scaling of the microservices architecture.

## Getting Started

To run this microservices architecture locally:

1. Clone this repository to your local environment.
2. Ensure Docker and Docker Compose are installed.
3. Navigate to the project directory.
4. Run `docker-compose up` to start the entire microservices ecosystem.
5. Access the APIs through the designated ports provided by the Docker Compose setup.
   
## Usage and Configuration

Each API and data store may have specific configurations and endpoints. Refer to the documentation or configuration files within each service's directory for detailed setup instructions and API usage guidelines.

## Contribution Guidelines

Contributions to this microservices project are encouraged. If you have enhancements, bug fixes, or additional features to propose, please submit a pull request following the outlined contribution guidelines.

## License

This microservices project is licensed under the [MIT License](LICENSE).

## Disclaimer

Please note that while this project aims to provide a functional and cohesive microservices architecture, it is provided as-is. Users should ensure they have the necessary permissions and comply with relevant regulations when using or modifying this architecture.

For any inquiries or issues, please contact the project maintainers.

**Maintainers:**  
Neel Acharya - neel.acharya@gmail.com


**Last Updated:** 25-Nov-2023
