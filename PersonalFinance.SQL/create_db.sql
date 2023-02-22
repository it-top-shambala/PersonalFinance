DROP TABLE tab_operations;
DROP TABLE tab_wallets;
DROP TABLE tab_categories;
DROP TABLE tab_currencies;
DROP TABLE tab_backgrounds;

CREATE TABLE tab_currencies
(
    currency_id   INT         NOT NULL PRIMARY KEY AUTO_INCREMENT,
    currency_name VARCHAR(10) NOT NULL,
    currency_code VARCHAR(10) NOT NULL
);

INSERT INTO tab_currencies (currency_name, currency_code)
VALUES ('RUR', 'no_code');
INSERT INTO tab_currencies (currency_name, currency_code)
VALUES ('USD', 'R01235');
INSERT INTO tab_currencies (currency_name, currency_code)
VALUES ('EUR', 'R01239');

CREATE TABLE tab_categories
(
    category_id   INT  NOT NULL PRIMARY KEY AUTO_INCREMENT,
    category_name TEXT NOT NULL,
    type          BOOL NOT NULL
);

CREATE TABLE tab_wallets
(
    wallet_id   INT           NOT NULL PRIMARY KEY AUTO_INCREMENT,
    wallet_name TEXT          NOT NULL,
    currency_id INT           NOT NULL,
    balance     DECIMAL(8, 2) NOT NULL,
    FOREIGN KEY (currency_id) REFERENCES tab_currencies (currency_id)
        ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE tab_operations
(
    operation_id   INT           NOT NULL PRIMARY KEY AUTO_INCREMENT,
    wallet_id      INT           NOT NULL,
    category_id    INT           NOT NULL,
    operation_date TEXT          NOT NULL,
    sum            DECIMAL(8, 2) NOT NULL,
    FOREIGN KEY (wallet_id) REFERENCES tab_wallets (wallet_id)
        ON UPDATE NO ACTION ON DELETE NO ACTION,
    FOREIGN KEY (category_id) REFERENCES tab_categories (category_id)
        ON UPDATE NO ACTION ON DELETE NO ACTION
);

CREATE TABLE tab_backgrounds
(
    wallet_id  INT          NOT NULL,
    background VARCHAR(100) NOT NULL
);