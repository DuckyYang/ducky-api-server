/*
 Navicat MySQL Data Transfer

 Source Server         : dat
 Source Server Type    : MySQL
 Source Server Version : 80019
 Source Host           : localhost:3306
 Source Schema         : dat

 Target Server Type    : MySQL
 Target Server Version : 80019
 File Encoding         : 65001

 Date: 15/06/2020 18:46:29
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for dat_menu
-- ----------------------------
DROP TABLE IF EXISTS `dat_menu`;
CREATE TABLE `dat_menu`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `menu` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `path` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `icon` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `enabled` bit(1) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dat_menu
-- ----------------------------
INSERT INTO `dat_menu` VALUES ('5b819459ac7d11eabbc300ff17336a76', 'Settings', '/settings', '系统设置', 'el-icon-setting', b'1');
INSERT INTO `dat_menu` VALUES ('72dce7bbac7d11eabbc300ff17336a76', 'Logs', '/logs', '接口日志', 'el-icon-s-data', b'1');
INSERT INTO `dat_menu` VALUES ('7a3ee3e3ac7d11eabbc300ff17336a76', 'Servers', '/servers', '接口管理', 'el-icon-s-promotion', b'1');
INSERT INTO `dat_menu` VALUES ('8aa6ff38ac7d11eabbc300ff17336a76', 'DashBoard', '/', '仪表盘', 'el-icon-s-home', b'1');
INSERT INTO `dat_menu` VALUES ('8ff56940ac7d11eabbc300ff17336a76', 'Documents', '/documents', '接口文档', 'el-icon-document', b'1');
INSERT INTO `dat_menu` VALUES ('94bb32ccac7d11eabbc300ff17336a76', 'MockServer', '/MockServer', '模拟服务', 'el-icon-s-platform', b'1');
INSERT INTO `dat_menu` VALUES ('996c4e1fac7d11eabbc300ff17336a76', 'Users', '/Users', '系统用户', 'el-icon-s-custom', b'1');
INSERT INTO `dat_menu` VALUES ('9f654aa5ac7d11eabbc300ff17336a76', 'Roles', '/Roles', '系统角色', 'el-icon-s-platform', b'1');

-- ----------------------------
-- Table structure for dat_role
-- ----------------------------
DROP TABLE IF EXISTS `dat_role`;
CREATE TABLE `dat_role`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `role` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `enabled` bit(1) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dat_role
-- ----------------------------
INSERT INTO `dat_role` VALUES ('627b0d76ac7c11eabbc300ff17336a76', 'admin', b'1');
INSERT INTO `dat_role` VALUES ('627cf440ac7c11eabbc300ff17336a76', 'user', b'1');

-- ----------------------------
-- Table structure for dat_role_auth
-- ----------------------------
DROP TABLE IF EXISTS `dat_role_auth`;
CREATE TABLE `dat_role_auth`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `roleid` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `menuid` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `view` bit(1) NOT NULL,
  `operate` bit(1) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for dat_servers
-- ----------------------------
DROP TABLE IF EXISTS `dat_servers`;
CREATE TABLE `dat_servers`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `default_headers` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `enabled` bit(1) NOT NULL,
  `order` int(0) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for dat_user
-- ----------------------------
DROP TABLE IF EXISTS `dat_user`;
CREATE TABLE `dat_user`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `role` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `inserttime` datetime(0) NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `mobile` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `enabled` bit(1) NOT NULL,
  `locked` bit(1) NOT NULL,
  `accesstoken` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `expired` datetime(6) NOT NULL ON UPDATE CURRENT_TIMESTAMP(6),
  `errortimes` int(0) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dat_user
-- ----------------------------
INSERT INTO `dat_user` VALUES ('1DA3F486B85C490DA3B58C05979AF8B5', 'Xu Xiang', 'd064cf3d3e6e493f4cc40d1f698d2544', 'admin', '2020-06-13 14:08:48', 'xx7057@cnki.net', '13146526301', b'1', b'0', '', '0001-01-01 00:00:00.000000', 0);
INSERT INTO `dat_user` VALUES ('a856d22faba311eabbc300ff17336a76', 'Ducky Yang', 'fe0ec45240b7d9cbb10653004a4075e9', 'admin', '2020-06-11 13:23:18', 'duckyyang@vip.qq.com', '18511284334', b'1', b'0', '38F5E8993719480EBBC3260A91496D30', '2020-06-13 12:47:40.846001', 0);
INSERT INTO `dat_user` VALUES ('CB531F03B8B94E9DBA1F85EF9736A10A', 'Gao Lidong', 'e10adc3949ba59abbe56e057f20f883e', 'admin', '2020-06-11 17:59:20', 'gld@cnki.net', '18511803221', b'1', b'0', '18754863CA324AF2BCA758223861B318', '2020-06-13 15:17:07.084275', 0);

-- ----------------------------
-- Table structure for dat_user_servers
-- ----------------------------
DROP TABLE IF EXISTS `dat_user_servers`;
CREATE TABLE `dat_user_servers`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `user_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `server_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
