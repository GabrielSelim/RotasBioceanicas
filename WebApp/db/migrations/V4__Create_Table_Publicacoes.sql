CREATE TABLE `publicacoes` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `title` VARCHAR(200) NOT NULL,
    `content` TEXT NOT NULL,
    `image_url` VARCHAR(500) NULL,
    `is_published` BOOLEAN NOT NULL DEFAULT FALSE,
    `published_at` DATETIME NOT NULL,
    `author_id` INT NOT NULL,
    PRIMARY KEY (`id`),
    CONSTRAINT `fk_publicacoes_autor`
        FOREIGN KEY (`author_id`)
        REFERENCES `usuarios` (`id`)
        ON DELETE CASCADE
)
ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;