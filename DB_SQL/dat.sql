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

 Date: 16/06/2020 17:38:42
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
  `order` int(0) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dat_menu
-- ----------------------------
INSERT INTO `dat_menu` VALUES ('5b819459ac7d11eabbc300ff17336a76', 'Settings', '/settings', '系统设置', 'el-icon-setting', b'1', 8);
INSERT INTO `dat_menu` VALUES ('72dce7bbac7d11eabbc300ff17336a76', 'Logs', '/logs', '接口日志', 'el-icon-s-data', b'1', 2);
INSERT INTO `dat_menu` VALUES ('7a3ee3e3ac7d11eabbc300ff17336a76', 'Servers', '/servers', '接口管理', 'el-icon-s-promotion', b'1', 3);
INSERT INTO `dat_menu` VALUES ('8ff56940ac7d11eabbc300ff17336a76', 'Documents', '/documents', '接口文档', 'el-icon-document', b'1', 4);
INSERT INTO `dat_menu` VALUES ('94bb32ccac7d11eabbc300ff17336a76', 'MockServer', '/MockServer', '模拟服务', 'el-icon-s-platform', b'1', 5);
INSERT INTO `dat_menu` VALUES ('996c4e1fac7d11eabbc300ff17336a76', 'Users', '/Users', '系统用户', 'el-icon-s-custom', b'1', 6);
INSERT INTO `dat_menu` VALUES ('9f654aa5ac7d11eabbc300ff17336a76', 'Roles', '/Roles', '系统角色', 'el-icon-s-platform', b'1', 7);

-- ----------------------------
-- Table structure for dat_role
-- ----------------------------
DROP TABLE IF EXISTS `dat_role`;
CREATE TABLE `dat_role`  (
  `role` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `enabled` bit(1) NOT NULL,
  PRIMARY KEY (`role`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dat_role
-- ----------------------------
INSERT INTO `dat_role` VALUES ('admin', b'1');
INSERT INTO `dat_role` VALUES ('master', b'1');
INSERT INTO `dat_role` VALUES ('user', b'1');

-- ----------------------------
-- Table structure for dat_role_auth
-- ----------------------------
DROP TABLE IF EXISTS `dat_role_auth`;
CREATE TABLE `dat_role_auth`  (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `role` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `menuid` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `view` tinyint(1) NOT NULL,
  `operate` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_0900_ai_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of dat_role_auth
-- ----------------------------
INSERT INTO `dat_role_auth` VALUES ('0E13CCCA016544D4AD878B96F74630A8', 'master', '9f654aa5ac7d11eabbc300ff17336a76', 0, 0);
INSERT INTO `dat_role_auth` VALUES ('120AD1630E4D44D38AB4012620552787', 'master', '8ff56940ac7d11eabbc300ff17336a76', 0, 0);
INSERT INTO `dat_role_auth` VALUES ('2200c41daf8e11ea999e00ff17336a76', 'admin', '5b819459ac7d11eabbc300ff17336a76', 1, 1);
INSERT INTO `dat_role_auth` VALUES ('2200d5f5af8e11ea999e00ff17336a76', 'admin', '72dce7bbac7d11eabbc300ff17336a76', 1, 1);
INSERT INTO `dat_role_auth` VALUES ('2200e7f3af8e11ea999e00ff17336a76', 'admin', '7a3ee3e3ac7d11eabbc300ff17336a76', 1, 1);
INSERT INTO `dat_role_auth` VALUES ('2200e8a4af8e11ea999e00ff17336a76', 'admin', '8ff56940ac7d11eabbc300ff17336a76', 1, 1);
INSERT INTO `dat_role_auth` VALUES ('2200e94baf8e11ea999e00ff17336a76', 'admin', '94bb32ccac7d11eabbc300ff17336a76', 1, 1);
INSERT INTO `dat_role_auth` VALUES ('2200e9afaf8e11ea999e00ff17336a76', 'admin', '996c4e1fac7d11eabbc300ff17336a76', 1, 1);
INSERT INTO `dat_role_auth` VALUES ('2200ea0baf8e11ea999e00ff17336a76', 'admin', '9f654aa5ac7d11eabbc300ff17336a76', 1, 1);
INSERT INTO `dat_role_auth` VALUES ('27287d58af8e11ea999e00ff17336a76', 'user', '5b819459ac7d11eabbc300ff17336a76', 1, 0);
INSERT INTO `dat_role_auth` VALUES ('27288c7daf8e11ea999e00ff17336a76', 'user', '72dce7bbac7d11eabbc300ff17336a76', 1, 0);
INSERT INTO `dat_role_auth` VALUES ('27288d38af8e11ea999e00ff17336a76', 'user', '7a3ee3e3ac7d11eabbc300ff17336a76', 1, 0);
INSERT INTO `dat_role_auth` VALUES ('27288dccaf8e11ea999e00ff17336a76', 'user', '8ff56940ac7d11eabbc300ff17336a76', 1, 0);
INSERT INTO `dat_role_auth` VALUES ('27288e59af8e11ea999e00ff17336a76', 'user', '94bb32ccac7d11eabbc300ff17336a76', 1, 0);
INSERT INTO `dat_role_auth` VALUES ('27288eb8af8e11ea999e00ff17336a76', 'user', '996c4e1fac7d11eabbc300ff17336a76', 1, 0);
INSERT INTO `dat_role_auth` VALUES ('27288f0eaf8e11ea999e00ff17336a76', 'user', '9f654aa5ac7d11eabbc300ff17336a76', 1, 0);
INSERT INTO `dat_role_auth` VALUES ('583198FA85964D9AAB2D499C30E8C10C', 'master', '72dce7bbac7d11eabbc300ff17336a76', 1, 0);
INSERT INTO `dat_role_auth` VALUES ('685F9B209AFF4E93BC134A37A763EA43', 'master', '996c4e1fac7d11eabbc300ff17336a76', 0, 0);
INSERT INTO `dat_role_auth` VALUES ('A3D265B18CAE4CC88A06B71645E44A59', 'master', '5b819459ac7d11eabbc300ff17336a76', 0, 0);
INSERT INTO `dat_role_auth` VALUES ('CD9812C52BA441889C543F9DEDEA0D7C', 'master', '7a3ee3e3ac7d11eabbc300ff17336a76', 1, 0);
INSERT INTO `dat_role_auth` VALUES ('D3F264BDA72A4C1F8AD2CCE76FE7DA99', 'master', '94bb32ccac7d11eabbc300ff17336a76', 0, 0);

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
