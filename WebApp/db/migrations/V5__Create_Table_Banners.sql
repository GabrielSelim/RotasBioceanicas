CREATE TABLE `banners` (
    `id` INT NOT NULL AUTO_INCREMENT,
    `image_url` VARCHAR(500) NOT NULL,
    `title` VARCHAR(100) NULL,
    `subtitle` VARCHAR(250) NULL,
    `link_url` VARCHAR(500) NULL,
    `display_order` INT NOT NULL DEFAULT 0,
    `is_active` BOOLEAN NOT NULL DEFAULT TRUE,
    `created_at` DATETIME NOT NULL,
    `updated_at` DATETIME NULL,
    PRIMARY KEY (`id`)
)
ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;