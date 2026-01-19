-- Create Tables
CREATE TABLE IF NOT EXISTS paddles (
    id SERIAL PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    brand VARCHAR(100) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    description TEXT,
    surface_material VARCHAR(100),
    core_material VARCHAR(100),
    weight_oz DECIMAL(4, 2),
    is_approved BOOLEAN DEFAULT TRUE
);

CREATE TABLE IF NOT EXISTS paddle_images (
    id SERIAL PRIMARY KEY,
    paddle_id INT REFERENCES paddles(id) ON DELETE CASCADE,
    image_url VARCHAR(500) NOT NULL,
    is_primary BOOLEAN DEFAULT FALSE
);

CREATE TABLE IF NOT EXISTS paddle_reviews (
    id SERIAL PRIMARY KEY,
    paddle_id INT REFERENCES paddles(id) ON DELETE CASCADE,
    reviewer_name VARCHAR(100) NOT NULL,
    rating INT CHECK (rating >= 1 AND rating <= 5),
    comment TEXT,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

-- Seed Data
INSERT INTO paddles (name, brand, price, description, surface_material, core_material, weight_oz, is_approved) VALUES 
('Hyperion CFS 16', 'JOOLA', 219.95, 'A rigorous paddle for control and spin.', 'Carbon Friction Surface', 'Reactive Honeycomb', 8.4, true),
('Power Air Invikta', 'Selkirk', 250.00, 'The ultimate power paddle with aerodynamic design.', 'Fiberglass', 'Polymer Honeycomb', 7.9, true),
('Black Diamond Power', 'Six Zero', 180.00, 'Designed for power and pop.', 'Raw Carbon Fiber', 'Polymer Honeycomb', 8.1, true);

INSERT INTO paddle_images (paddle_id, image_url, is_primary) VALUES
(1, 'https://placehold.co/400x600?text=Joola+Hyperion', true),
(1, 'https://placehold.co/400x600?text=Joola+Side', false),
(2, 'https://placehold.co/400x600?text=Selkirk+Invikta', true),
(3, 'https://placehold.co/400x600?text=Six+Zero+BD', true);

INSERT INTO paddle_reviews (paddle_id, reviewer_name, rating, comment) VALUES
(1, 'Ben Johns', 5, 'Best paddle I have ever used. Great spin.', '2023-01-15 10:00:00'),
(1, 'Amateur Andy', 4, 'A bit heavy but solid.', '2023-01-16 14:30:00'),
(2, 'Power Player', 5, 'Insane power, ball flies off the face.', '2023-02-01 09:15:00'),
(3, 'Spin Doctor', 5, 'Great value for the price.', '2023-02-10 11:45:00');
