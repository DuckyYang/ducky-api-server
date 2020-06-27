/*
 Navicat MySQL Data Transfer

 Source Server         : dat
 Source Server Type    : MySQL
 Source Server Version : 80018
 Source Host           : localhost:3306
 Source Schema         : dat

 Target Server Type    : MySQL
 Target Server Version : 80018
 File Encoding         : 65001

 Date: 27/06/2020 22:06:52
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for dat_collection
-- ----------------------------
DROP TABLE IF EXISTS `dat_collection`;
CREATE TABLE `dat_collection` (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `inserttime` datetime NOT NULL,
  `server_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dat_collection
-- ----------------------------
BEGIN;
INSERT INTO `dat_collection` VALUES ('7EF1696D8D5E4554AE1B1A0741146804', '加班接口', '2020-06-27 19:11:58', 'F133B98847274482A2B1DC3B849F659D');
INSERT INTO `dat_collection` VALUES ('88EC508814074F2E8DBD61454CBA1D1A', '请假接口', '2020-06-26 13:27:50', 'F133B98847274482A2B1DC3B849F659D');
COMMIT;

-- ----------------------------
-- Table structure for dat_menu
-- ----------------------------
DROP TABLE IF EXISTS `dat_menu`;
CREATE TABLE `dat_menu` (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `menu` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `path` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `icon` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `enabled` bit(1) NOT NULL,
  `order` int(11) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dat_menu
-- ----------------------------
BEGIN;
INSERT INTO `dat_menu` VALUES ('5b819459ac7d11eabbc300ff17336a76', 'Settings', '/settings', '系统设置', 'el-icon-setting', b'1', 8);
INSERT INTO `dat_menu` VALUES ('72dce7bbac7d11eabbc300ff17336a76', 'Logs', '/logs', '接口日志', 'el-icon-s-data', b'1', 2);
INSERT INTO `dat_menu` VALUES ('7a3ee3e3ac7d11eabbc300ff17336a76', 'Servers', '/servers', '接口管理', 'el-icon-s-promotion', b'1', 3);
INSERT INTO `dat_menu` VALUES ('8ff56940ac7d11eabbc300ff17336a76', 'Documents', '/documents', '接口文档', 'el-icon-document', b'1', 4);
INSERT INTO `dat_menu` VALUES ('94bb32ccac7d11eabbc300ff17336a76', 'MockServer', '/MockServer', '模拟服务', 'el-icon-s-platform', b'1', 5);
INSERT INTO `dat_menu` VALUES ('996c4e1fac7d11eabbc300ff17336a76', 'Users', '/Users', '系统用户', 'el-icon-s-custom', b'1', 6);
INSERT INTO `dat_menu` VALUES ('9f654aa5ac7d11eabbc300ff17336a76', 'Roles', '/Roles', '系统角色', 'el-icon-s-platform', b'1', 7);
COMMIT;

-- ----------------------------
-- Table structure for dat_request
-- ----------------------------
DROP TABLE IF EXISTS `dat_request`;
CREATE TABLE `dat_request` (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `collection_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '隶属的集合ID',
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '名称',
  `method` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '请求方法：GET,POST,PUT,DELETE,OPTIONS',
  `address` varchar(500) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '接口完整地址',
  `content_type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT 'json & form & params',
  `json` text CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '当contenttype=json时的参数配置',
  `response` varchar(5000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL COMMENT '最后一次请求时服务器的响应数据',
  `inserttime` datetime NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dat_request
-- ----------------------------
BEGIN;
INSERT INTO `dat_request` VALUES ('53859C1CD9714026AD8D7A2727AB1B53', '88EC508814074F2E8DBD61454CBA1D1A', '添加请假', 'POST', 'http://oa.cnki.net/hrmanage/askforleave', 'form', '', '', '2020-06-26 13:30:45');
INSERT INTO `dat_request` VALUES ('66EABFACC4434ADBB2FE6561A1733C92', '7EF1696D8D5E4554AE1B1A0741146804', '添加加班申请', 'POST', 'http://oa.cnki.net/hrmanage/overtime', '', '', '', '2020-06-27 19:12:06');
INSERT INTO `dat_request` VALUES ('AB7753CC3436418CA34DDDB2C66D56E6', '88EC508814074F2E8DBD61454CBA1D1A', '删除请假', 'DELETE', 'http://oa.cnki.net/hrmanage/askforleave/{id}', '', '', '', '2020-06-27 10:33:58');
INSERT INTO `dat_request` VALUES ('D9EED5BFA9D3462C84F96CDEF41B4E45', '88EC508814074F2E8DBD61454CBA1D1A', '修改请假', 'PUT', 'http://oa.cnki.net/hrmanage/askforleave/{id}', 'json', '{\n  \"start\": \"2020-01-01\",\n  \"end\": \"2020-02-01\"\n}', '', '2020-06-26 17:35:43');
COMMIT;

-- ----------------------------
-- Table structure for dat_request_body
-- ----------------------------
DROP TABLE IF EXISTS `dat_request_body`;
CREATE TABLE `dat_request_body` (
  `id` varchar(50) NOT NULL,
  `request_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `key` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL DEFAULT '',
  `inserttime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of dat_request_body
-- ----------------------------
BEGIN;
INSERT INTO `dat_request_body` VALUES ('89868784D48B4592AD1E5680177E476F', '53859C1CD9714026AD8D7A2727AB1B53', 'start', '2020-01-01', '2020-06-26 18:47:04');
INSERT INTO `dat_request_body` VALUES ('E1517BAB71C84052B0C7B2F6B192D5AE', '53859C1CD9714026AD8D7A2727AB1B53', 'end', '2020-03-01', '2020-06-26 18:47:04');
COMMIT;

-- ----------------------------
-- Table structure for dat_request_headers
-- ----------------------------
DROP TABLE IF EXISTS `dat_request_headers`;
CREATE TABLE `dat_request_headers` (
  `id` varchar(50) NOT NULL,
  `request_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `key` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `value` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `inserttime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of dat_request_headers
-- ----------------------------
BEGIN;
INSERT INTO `dat_request_headers` VALUES ('784EE1036B414F7EB06169DC12F9377B', 'D9EED5BFA9D3462C84F96CDEF41B4E45', 'accesstoken', 'duckyyang', '2020-06-26 18:52:32');
INSERT INTO `dat_request_headers` VALUES ('953F10712B8F4DBBAB98EBC74361E89C', 'AB7753CC3436418CA34DDDB2C66D56E6', 'accesstoken', 'duckyyang', '2020-06-27 19:09:47');
INSERT INTO `dat_request_headers` VALUES ('D708217116804555B28B5372F091BE8C', '53859C1CD9714026AD8D7A2727AB1B53', 'accesstoken', 'duckyyang', '2020-06-26 18:47:04');
INSERT INTO `dat_request_headers` VALUES ('FEEB78FB45BF4C41A801FDF6F956DF4B', '66EABFACC4434ADBB2FE6561A1733C92', 'accesstoken', 'duckyyang', '2020-06-27 19:15:43');
COMMIT;

-- ----------------------------
-- Table structure for dat_request_params
-- ----------------------------
DROP TABLE IF EXISTS `dat_request_params`;
CREATE TABLE `dat_request_params` (
  `id` varchar(50) NOT NULL,
  `request_id` varchar(50) NOT NULL,
  `key` varchar(255) NOT NULL,
  `value` varchar(255) NOT NULL,
  `inserttime` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- ----------------------------
-- Records of dat_request_params
-- ----------------------------
BEGIN;
COMMIT;

-- ----------------------------
-- Table structure for dat_role
-- ----------------------------
DROP TABLE IF EXISTS `dat_role`;
CREATE TABLE `dat_role` (
  `role` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `enabled` bit(1) NOT NULL,
  PRIMARY KEY (`role`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dat_role
-- ----------------------------
BEGIN;
INSERT INTO `dat_role` VALUES ('admin', b'1');
INSERT INTO `dat_role` VALUES ('master', b'1');
INSERT INTO `dat_role` VALUES ('user', b'1');
COMMIT;

-- ----------------------------
-- Table structure for dat_role_auth
-- ----------------------------
DROP TABLE IF EXISTS `dat_role_auth`;
CREATE TABLE `dat_role_auth` (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `role` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `menuid` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `viewable` bit(1) NOT NULL,
  `operable` bit(1) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dat_role_auth
-- ----------------------------
BEGIN;
INSERT INTO `dat_role_auth` VALUES ('0E13CCCA016544D4AD878B96F74630A8', 'master', '9f654aa5ac7d11eabbc300ff17336a76', b'0', b'0');
INSERT INTO `dat_role_auth` VALUES ('120AD1630E4D44D38AB4012620552787', 'master', '8ff56940ac7d11eabbc300ff17336a76', b'0', b'1');
INSERT INTO `dat_role_auth` VALUES ('2200c41daf8e11ea999e00ff17336a76', 'admin', '5b819459ac7d11eabbc300ff17336a76', b'1', b'1');
INSERT INTO `dat_role_auth` VALUES ('2200d5f5af8e11ea999e00ff17336a76', 'admin', '72dce7bbac7d11eabbc300ff17336a76', b'1', b'1');
INSERT INTO `dat_role_auth` VALUES ('2200e7f3af8e11ea999e00ff17336a76', 'admin', '7a3ee3e3ac7d11eabbc300ff17336a76', b'1', b'1');
INSERT INTO `dat_role_auth` VALUES ('2200e8a4af8e11ea999e00ff17336a76', 'admin', '8ff56940ac7d11eabbc300ff17336a76', b'1', b'1');
INSERT INTO `dat_role_auth` VALUES ('2200e94baf8e11ea999e00ff17336a76', 'admin', '94bb32ccac7d11eabbc300ff17336a76', b'1', b'1');
INSERT INTO `dat_role_auth` VALUES ('2200e9afaf8e11ea999e00ff17336a76', 'admin', '996c4e1fac7d11eabbc300ff17336a76', b'1', b'1');
INSERT INTO `dat_role_auth` VALUES ('2200ea0baf8e11ea999e00ff17336a76', 'admin', '9f654aa5ac7d11eabbc300ff17336a76', b'1', b'1');
INSERT INTO `dat_role_auth` VALUES ('27287d58af8e11ea999e00ff17336a76', 'user', '5b819459ac7d11eabbc300ff17336a76', b'1', b'0');
INSERT INTO `dat_role_auth` VALUES ('27288c7daf8e11ea999e00ff17336a76', 'user', '72dce7bbac7d11eabbc300ff17336a76', b'1', b'0');
INSERT INTO `dat_role_auth` VALUES ('27288d38af8e11ea999e00ff17336a76', 'user', '7a3ee3e3ac7d11eabbc300ff17336a76', b'1', b'0');
INSERT INTO `dat_role_auth` VALUES ('27288dccaf8e11ea999e00ff17336a76', 'user', '8ff56940ac7d11eabbc300ff17336a76', b'1', b'0');
INSERT INTO `dat_role_auth` VALUES ('27288e59af8e11ea999e00ff17336a76', 'user', '94bb32ccac7d11eabbc300ff17336a76', b'1', b'0');
INSERT INTO `dat_role_auth` VALUES ('27288eb8af8e11ea999e00ff17336a76', 'user', '996c4e1fac7d11eabbc300ff17336a76', b'1', b'0');
INSERT INTO `dat_role_auth` VALUES ('27288f0eaf8e11ea999e00ff17336a76', 'user', '9f654aa5ac7d11eabbc300ff17336a76', b'1', b'0');
INSERT INTO `dat_role_auth` VALUES ('583198FA85964D9AAB2D499C30E8C10C', 'master', '72dce7bbac7d11eabbc300ff17336a76', b'1', b'1');
INSERT INTO `dat_role_auth` VALUES ('685F9B209AFF4E93BC134A37A763EA43', 'master', '996c4e1fac7d11eabbc300ff17336a76', b'0', b'0');
INSERT INTO `dat_role_auth` VALUES ('A3D265B18CAE4CC88A06B71645E44A59', 'master', '5b819459ac7d11eabbc300ff17336a76', b'0', b'0');
INSERT INTO `dat_role_auth` VALUES ('CD9812C52BA441889C543F9DEDEA0D7C', 'master', '7a3ee3e3ac7d11eabbc300ff17336a76', b'1', b'1');
INSERT INTO `dat_role_auth` VALUES ('D3F264BDA72A4C1F8AD2CCE76FE7DA99', 'master', '94bb32ccac7d11eabbc300ff17336a76', b'0', b'0');
COMMIT;

-- ----------------------------
-- Table structure for dat_servers
-- ----------------------------
DROP TABLE IF EXISTS `dat_servers`;
CREATE TABLE `dat_servers` (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `default_headers` varchar(1000) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `enabled` bit(1) NOT NULL,
  `order` int(11) NOT NULL,
  `base_url` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dat_servers
-- ----------------------------
BEGIN;
INSERT INTO `dat_servers` VALUES ('D3FE0C3108D34C3E9CC48FCF95F69B8A', '工作流2.0', 'accesstoken', b'1', 10, 'http://oa.cnki.net/api/workflow2.0');
INSERT INTO `dat_servers` VALUES ('F133B98847274482A2B1DC3B849F659D', '人事类接口', 'accesstoken', b'1', 20, 'http://oa.cnki.net/api/hrmanage');
COMMIT;

-- ----------------------------
-- Table structure for dat_user
-- ----------------------------
DROP TABLE IF EXISTS `dat_user`;
CREATE TABLE `dat_user` (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `password` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `role` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `inserttime` datetime NOT NULL,
  `email` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `mobile` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `enabled` bit(1) NOT NULL,
  `locked` bit(1) NOT NULL,
  `accesstoken` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `expired` datetime(6) NOT NULL ON UPDATE CURRENT_TIMESTAMP(6),
  `errortimes` int(11) NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dat_user
-- ----------------------------
BEGIN;
INSERT INTO `dat_user` VALUES ('1DA3F486B85C490DA3B58C05979AF8B5', 'Xu Xiang', 'd064cf3d3e6e493f4cc40d1f698d2544', 'user', '2020-06-13 14:08:48', 'xx7057@cnki.net', '13146526301', b'1', b'0', '', '2020-06-16 18:32:19.176262', 0);
INSERT INTO `dat_user` VALUES ('a856d22faba311eabbc300ff17336a76', 'Ducky Yang', 'fe0ec45240b7d9cbb10653004a4075e9', 'admin', '2020-06-11 13:23:18', 'duckyyang@vip.qq.com', '18511284334', b'1', b'0', '692F9764CF664E7C8E3434F60DC7FA58', '2020-06-18 12:41:18.511121', 0);
INSERT INTO `dat_user` VALUES ('CB531F03B8B94E9DBA1F85EF9736A10A', 'Gao Lidong', 'e10adc3949ba59abbe56e057f20f883e', 'admin', '2020-06-11 17:59:20', 'gld11298@cnki.net', '18511803221', b'1', b'0', '18754863CA324AF2BCA758223861B318', '2020-06-18 14:25:29.444625', 0);
COMMIT;

-- ----------------------------
-- Table structure for dat_user_servers
-- ----------------------------
DROP TABLE IF EXISTS `dat_user_servers`;
CREATE TABLE `dat_user_servers` (
  `id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `user_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `server_id` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci ROW_FORMAT=DYNAMIC;

-- ----------------------------
-- Records of dat_user_servers
-- ----------------------------
BEGIN;
COMMIT;

SET FOREIGN_KEY_CHECKS = 1;
